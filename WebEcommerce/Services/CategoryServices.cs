using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebEcommerce.Data;
using WebEcommerce.Models;

namespace WebEcommerce.Services
{
    public class CategoryServices : ICategoryServices
    {

        private readonly ApplicationDbContext _context;

        public CategoryServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()        
            => await _context.Categories.ToListAsync();
           

        public Task<Category> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Category entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
