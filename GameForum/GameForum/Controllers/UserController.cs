using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameForum.ApplicationLogic.Abstractions;
using GameForum.ApplicationLogic.Model;
using Microsoft.AspNetCore.Mvc;

namespace GameForum.Controllers
{
    public class UserController : Controller
    {
        private IComment commentRepository;
        public UserController(IComment commentRepository)
        {
            this.commentRepository = commentRepository;
        }
        public IActionResult Comment()
        {
            return View();
        }
        public ActionResult CreateClick(string text)
        {
            //commentRepository.Add(new Comment { Text = })
            
            
            return RedirectToAction("Comment", "User");
        }
    }
}