using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ITHub.Models;
using ITHub.Services.Contracts;

namespace ITHub.Controllers
{
    public class HomeController : Controller
    {
        private ISongsService service;
       
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ISongsService service)
        {
            _logger = logger;
            this.service = service;
        }

        public IActionResult Test()
        {
            return View();
        }

        public IActionResult Index()
        {
            var model = service.GetAllSongs();
            return View(model);
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
    }
}
