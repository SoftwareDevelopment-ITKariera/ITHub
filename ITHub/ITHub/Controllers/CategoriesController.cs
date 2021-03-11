using ITHub.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITHub.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoriesService service;

        public CategoriesController(ICategoriesService service)
        {
            this.service = service;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            this.service.CreateCategory(name);
            return this.RedirectToAction("Index", "Home");
        }
    }
}
