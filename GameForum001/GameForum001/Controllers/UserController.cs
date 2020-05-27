using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GameForum.ApplicationLogic.Abstractions;
using GameForum.ApplicationLogic.Model;
using GameForum.DataAccess;
using GameForum.EFDataAccess;
using GameForum001.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameForum.Controllers
{
    public class UserController : Controller
    {
        private IComment commentRepository;
        private IGame gameRepository;
        //private IRepository<Comment> _repo;
        private readonly UserManager<IdentityUser> userManager;
        //private IUser userRep;
        public UserController(UserManager<IdentityUser> userManager, IComment commentRepository, IGame gameRepository)
        {
            //this.commentRepository = commentRepository;
           // this._repo = _repo;
            this.userManager = userManager;
            this.commentRepository = commentRepository;
            this.gameRepository = gameRepository;
        }

        public IActionResult EditComment(Guid id)
        {
            ViewData.Model = commentRepository.GetCommentByCommentId(id);

            return View();
        }

        public IActionResult AddEditComment([FromForm]Comment form)
        {
            var tempCom = commentRepository.GetCommentByCommentId(form.CommentID);

            tempCom.Text = form.Text;

            commentRepository.Update(tempCom);

            return RedirectToAction("Comments", "User");
        }

        public IActionResult Comments(Guid id)
        {
            var comments = commentRepository.GetCommentForUserId(Guid.Parse(userManager.GetUserId(HttpContext.User)));
            var games = new List<Game>();
            foreach(var com in comments)
            {
                games.Add(gameRepository.GetGameByGameId(com.GameId));
            }
            List<UserCommentsMV> userComments = new List<UserCommentsMV>();
            foreach(var com in comments)
            {
                userComments.Add(new UserCommentsMV
                {
                    CommentID = com.CommentID,
                    Text = com.Text,
                    Title = gameRepository.GetGameByGameId(com.GameId).Title
                });
            }
            ViewData.Model = userComments;
            
            return View();
        }

        //[Authorize(Roles = "User")]
        public IActionResult AddComment( [FromForm]GamePageMV form)
        {
            //commentRepository.Add(new Comment { CommentID = Guid.NewGuid(), CreatorID = Guid.Parse(userManager.GetUserId(HttpContext.User)), Score = 0, Text = form.Text, GameId = 2 });
            //    _repo.Add(new Comment { CommentID = Guid.NewGuid(), CreatorID = userManager.GetUserId(HttpContext.User), Score = 0, Text = form.Text, GameId = 2 });
            commentRepository.Add(new Comment { CommentID = Guid.NewGuid(), CreatorID = Guid.Parse(userManager.GetUserId(HttpContext.User)), Score = form.Score, Text = form.Text, GameId = form.GameID });
            gameRepository.UpdateNOComments(form.GameID, true);
            gameRepository.UpdateScore(form.GameID);
            return RedirectToAction("ViewGames", "Home");
        }
        public IActionResult AddGame()
        {
            return View();
        }
        
        public IActionResult AddGameBtn([FromForm]AddGameMV form)
        {
            //commentRepository.Add(new Comment { CommentID = Guid.NewGuid(), CreatorID = Guid.Parse(userManager.GetUserId(HttpContext.User)), Score = 0, Text = form.Text, GameId = 2 });
            //_repo.Add(new Comment { CommentID = Guid.NewGuid(), CreatorID = userManager.GetUserId(HttpContext.User), Score = 0, Text = form.Text, GameId = 2 });

            string image = "";

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (var memoryStream = new MemoryStream())
            {
                form.Image.CopyTo(memoryStream);

                image = Convert.ToBase64String(memoryStream.ToArray());
            }

            gameRepository.Add(new Game { Image = image, Comments = null, Score = 0, Title = form.Title, Description = form.Description, CreatorID = Guid.Parse(userManager.GetUserId(HttpContext.User)), GameID = Guid.NewGuid(), DateCreated = DateTime.Now, NOComments = 0 });

            return RedirectToAction("AddGame", "User");
        }

        public IActionResult GamePage(Guid id)
        {
            //ViewData.Model = gameRepository.GetGameByGameId(id);
            var mod = gameRepository.GetGameByGameId(id);
            var comm = commentRepository.GetCommentForGameId(id);
            
            ViewData.Model = new GamePageMV
            {
                GameID = mod.GameID,
                Title = mod.Title,
                Description = mod.Description,
                Score = mod.Score,
                NOComments = mod.NOComments,
                Comments = comm,
                CreatorID = mod.CreatorID,
                Image = mod.Image,
                DateCreated = mod.DateCreated
            };
            return View();
        }

        public IActionResult Back()
        {
            return RedirectToAction("ViewGames", "Home");
        }

    }
}