using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebEcommerce.Data;
using WebEcommerce.Services;

namespace WebEcommerce.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductServices _services;

        public ProductsController(IProductServices services)
        {
            _services = services;
        }
        public async Task<IActionResult> Index()
        {
            var Response =await _services.GetAllAsync(x=>x.Category);
            return View(Response);
        }

        public async Task<IActionResult> Details(int id)
        {
            var Product = await _services.GetByIdAsync(id,x=>x.Category);
            return View(Product);
        }
    }
}
