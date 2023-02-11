using System.Collections.Generic;
using System.Threading.Tasks;
using WebEcommerce.Base;
using WebEcommerce.Models;

namespace WebEcommerce.Services
{
    public interface ICategoryServices : IBaseEntityRepository<Category>
    {
        /* Task<IEnumerable<Category>> GetAllAsync();
         Task<Category> GetByIdAsync(int id);
         Task CreateAsync(Category entity);
         Task UpdateAsync(Category entity);
         Task DeleteAsync(int id);*/
        Task CreateAsync(Category category);
    }
}
