using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebEcommerce.Data;
using WebEcommerce.Models;
using WebEcommerce.Services;

namespace WebEcommerce.Controllers
{
    public class CategoriesController : Controller
    {

        private readonly ICategoryServices _services;

        public CategoriesController(ICategoryServices services)
        {
            _services = services;
        }
        public async Task<IActionResult> Index()
        {
            var Response =await _services.GetAllAsync();
            return View(Response);
        }
        

        //Create Services
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Description")]Category category)
        {
                if (ModelState.IsValid)
                {
                   await _services.CreateAsync(category);
                return RedirectToAction(nameof(Index));
                }
                return View(category);
        } 
    }
}
