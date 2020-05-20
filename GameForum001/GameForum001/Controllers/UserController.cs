using System;
using System.Collections.Generic;
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

        public IActionResult Comment(Guid id)
        {
            ViewBag.gameId = id;
            string s = "";
            ViewBag.text = s;
            return View();
        }

        //[Authorize(Roles = "User")]
        public async Task<IActionResult> AddComment(Guid myvar, [FromForm]GamePageMV form)
        {
            //commentRepository.Add(new Comment { CommentID = Guid.NewGuid(), CreatorID = Guid.Parse(userManager.GetUserId(HttpContext.User)), Score = 0, Text = form.Text, GameId = 2 });
            //    _repo.Add(new Comment { CommentID = Guid.NewGuid(), CreatorID = userManager.GetUserId(HttpContext.User), Score = 0, Text = form.Text, GameId = 2 });
            commentRepository.Add(new Comment { CommentID = Guid.NewGuid(), CreatorID = Guid.Parse(userManager.GetUserId(HttpContext.User)), Score = 0, Text = form.Text, GameId = form.GameID });
            gameRepository.UpdateNOComments(form.GameID, true);
            return RedirectToAction("Comment", "User");
        }
        public IActionResult AddGame()
        {
            return View();
        }

        public async Task<IActionResult> AddGameBtn([FromForm]Game form)
        {
            //commentRepository.Add(new Comment { CommentID = Guid.NewGuid(), CreatorID = Guid.Parse(userManager.GetUserId(HttpContext.User)), Score = 0, Text = form.Text, GameId = 2 });
            //    _repo.Add(new Comment { CommentID = Guid.NewGuid(), CreatorID = userManager.GetUserId(HttpContext.User), Score = 0, Text = form.Text, GameId = 2 });
             gameRepository.Add(new Game { Comments = null, Score = 0, Title = form.Title, Description = form.Description, CreatorID = Guid.Parse(userManager.GetUserId(HttpContext.User)), GameID = Guid.NewGuid(), DateCreated = DateTime.Now, NOComments = 0 });
            
            return RedirectToAction("AddGame", "User");
        }

        public IActionResult GamePage(Guid id)
        {
            //ViewData.Model = gameRepository.GetGameByGameId(id);
            var mod = gameRepository.GetGameByGameId(id);
            //var com = commentRepository.GetCommentByGameId(id);
            var com = new Comment();
            ViewData.Model = new GamePageMV { GameID = mod.GameID, 
                Title = mod.Title, 
                Description = mod.Description, 
                Score = mod.Score, 
                NOComments = mod.NOComments, 
                Comments = mod.Comments,
                CreatorID = mod.CreatorID, 
                DateCreated = mod.DateCreated };
            return View();
        }

        public IActionResult Back()
        {
            return RedirectToAction("ViewGames", "Home");
        }

    }
}