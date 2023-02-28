using WebEcommerce.Base;
using WebEcommerce.Data;
using WebEcommerce.Models;

namespace WebEcommerce.Services
{
    public class ProductServices:BaseEntityRepository<Product>,IProductServices
    {
        public ProductServices(ApplicationDbContext context):base(context)
        {
            
        }    
    }
}
