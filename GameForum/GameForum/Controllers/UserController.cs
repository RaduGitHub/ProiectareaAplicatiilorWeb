using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameForum.ApplicationLogic.Abstractions;
using GameForum.ApplicationLogic.Model;
using GameForum.DataAccess;
using GameForum.EFDataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameForum.Controllers
{
    public class UserController : Controller
    {
        private IComment commentRepository;
        //private IRepository<Comment> _repo;
        private readonly UserManager<IdentityUser> userManager;
        //private IUser userRep;
        public UserController(UserManager<IdentityUser> userManager, IComment commentRepository)
        {
            //this.commentRepository = commentRepository;
           // this._repo = _repo;
            this.userManager = userManager;
            this.commentRepository = commentRepository;
        }
        public IActionResult Comment()
        {
            return View();
        }
        public async Task<IActionResult> AddComment([FromForm]Comment form)
        {
            //commentRepository.Add(new Comment { CommentID = Guid.NewGuid(), CreatorID = userManager.GetUserId(HttpContext.User), Score = 0, Text = form.Text, GameId = 2 });
        //    _repo.Add(new Comment { CommentID = Guid.NewGuid(), CreatorID = userManager.GetUserId(HttpContext.User), Score = 0, Text = form.Text, GameId = 2 });

            return RedirectToAction("Comment", "User");
        }
    }
}