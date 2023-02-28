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

           public CategoryServices(ApplicationDbContext context):base(context)
        {
        }
    }
}
