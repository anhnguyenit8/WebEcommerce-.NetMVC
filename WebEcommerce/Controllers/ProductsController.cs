using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebEcommerce.Data;

namespace WebEcommerce.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var Response =await _context.Products.Include(x=>x.Category)
                .OrderBy(x=>x.Price)
                .ToListAsync();
            return View(Response);
        }
    }
}
