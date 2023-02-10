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

        public async Task DeleteAsync(int id)
        {
            var categoryId = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (categoryId != null)
            {
                _context.Categories.Remove(categoryId);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()        
            => await _context.Categories.ToListAsync();
           

        public async Task<Category> GetByIdAsync(int id)        
            => await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        

        public async Task UpdateAsync(Category entity)
        {
            var CategoryId = await _context.Categories.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if(CategoryId != null)
            {
                CategoryId.Id= entity.Id;
                CategoryId.Name= entity.Name;
                CategoryId.Description= entity.Description;
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
