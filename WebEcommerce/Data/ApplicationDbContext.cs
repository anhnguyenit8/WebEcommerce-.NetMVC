using Microsoft.EntityFrameworkCore;
using WebEcommerce.Models;

namespace WebEcommerce.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        { 

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get;set; }
       
    }
}
