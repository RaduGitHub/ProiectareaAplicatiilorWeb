using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameForum.ApplicationLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace GameForum.Controllers
{
    public class testController : Controller
    {
        private GameService gameRepository;
        public testController(GameService gameRepository)
        {
            this.gameRepository = gameRepository;
        }
        public IActionResult Index()
        {
            /*byte[] bytes = new byte[16];
            BitConverter.GetBytes(1).CopyTo(bytes, 0);
            gameRepository.GetCreatorId(new Guid(bytes));*/


            return View();
        }
    }
}