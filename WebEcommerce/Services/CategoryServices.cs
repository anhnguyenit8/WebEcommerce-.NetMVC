using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebEcommerce.Base;
using WebEcommerce.Data;
using WebEcommerce.Models;

namespace WebEcommerce.Services
{
    public class CategoryServices : BaseEntityRepository<Category>,ICategoryServices
    {

        private readonly ApplicationDbContext _context;
        public CategoryServices(ApplicationDbContext context):base(context)
        {
        }

        public Task CreateAsync(Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}
