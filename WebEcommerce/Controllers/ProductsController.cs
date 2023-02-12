using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebEcommerce.Data;
using WebEcommerce.Models;
using WebEcommerce.Services;

namespace WebEcommerce.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductServices _services;
        private readonly ICategoryServices _categoryServices;

        public ProductsController(IProductServices services, ICategoryServices categoryServices)
        {
            _services = services;
            _categoryServices = categoryServices;
        }
        public async Task<IActionResult> Index()
        {
            var Response =await _services.GetAllAsync(x=>x.Category);
            return View(Response);
        }

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
    }
}
