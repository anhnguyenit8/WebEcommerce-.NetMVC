using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebEnterpriseProject.Models;

namespace WebEnterpriseProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Comment> Comment { get; set; }
        /*public DbSet<Department> Department { get; set; }*/
        public DbSet<Post> Post { get; set; }
        public DbSet<User> User { get; set; }

    }
}

