using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebEcommerce.Data;
using WebEcommerce.Data.Enums;
using WebEcommerce.Data.Static;
using WebEcommerce.Models;
using WebEcommerce.Services;
using static Google.Apis.Requests.BatchRequest;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebEcommerce.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProductsController : Controller
    {
        
        private readonly IProductServices _services;
        private readonly ICategoryServices _categoryServices;

        public ProductsController(IProductServices services, ICategoryServices categoryServices)
        {
            
            _services = services;
            _categoryServices = categoryServices;
        }


        [AllowAnonymous]
        public async Task<IActionResult> Index(int? categoryId, string searchTerm)
        {

            var Response = await _services.GetAllAsync(x => x.Category);
            if (categoryId.HasValue)
            {
                Response = Response.Where(x => x.CategoryId == categoryId.Value);
            }
            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                Response = Response.Where(x => x.Name.ToLower().Contains(searchTerm));
            }
            return View(Response.ToList());
        }

        //TEST



        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var Product = await _services.GetByIdAsync(id, x => x.Category);
            return View(Product);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = await _categoryServices.GetAllAsync();
            return View();
        }

        [HttpPost,ActionName(nameof(Create))]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await _services.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View("NotFound");
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Category = await _categoryServices.GetAllAsync();
            var productId = await _services.GetByIdAsync(id, x => x.Category);
            return View(productId);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _services.UpdateAsync(product);
                return RedirectToAction($"{nameof(Index)}");
            }
            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> ProductsByCategory(int categoryId)
        {
            var products = await _services.GetAllAsync(x => x.Category);
            products = products.Where(x => x.CategoryId == categoryId);
            return View("Index", products.ToList());
        }



    }
}
