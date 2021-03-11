using ITHub.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITHub.Controllers
{
    public class SongsController : Controller
    {
        private ISongsService service;
        public SongsController(ISongsService service)
        {
            this.service = service;
        }
        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult Create(string name, string description, string link, string category)
        {

            service.CreateSong(name, description, link, category);
            return this.RedirectToAction("Index", "Home");
        }
    }
}
