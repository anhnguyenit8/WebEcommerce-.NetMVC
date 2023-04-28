using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebEcommerce.Base;
using WebEcommerce.Models;

namespace WebEcommerce.Services
{
    public interface IProductServices : IBaseEntityRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId, string categoryName);

    }
}
