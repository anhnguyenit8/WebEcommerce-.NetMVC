using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEcommerce.Base;
using WebEcommerce.Data;
using WebEcommerce.Models;

namespace WebEcommerce.Services
{
    public class ProductServices:BaseEntityRepository<Product>,IProductServices
    {
        private readonly ApplicationDbContext _context;        
        public ProductServices(ApplicationDbContext context):base(context)
        {
            
        }
        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId, string categoryName)
        {
            var products = await _context.Products.Where(p => p.CategoryId == categoryId && p.Category.Name == categoryName).ToListAsync();
            return products;
        }

    }
}
