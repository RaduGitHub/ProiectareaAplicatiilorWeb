using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GameForum001.Models;
using GameForum.ApplicationLogic.Abstractions;

namespace GameForum001.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IGame gameRepository;
        public HomeController(ILogger<HomeController> logger, IGame gameRepository)
        {
            _logger = logger;
            this.gameRepository = gameRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ViewGames()
        {
            ViewData.Model = gameRepository.GetAll();
            return View();
        }
    }
}
