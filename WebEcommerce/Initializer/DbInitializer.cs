using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEcommerce.Data;
using WebEcommerce.Data.Enums;
using WebEcommerce.Data.Static;
using WebEcommerce.Models;

namespace WebEcommerce.Initializer
{
    public class DbInitializer: IDbInitializer
    {
        public static void Seed(IApplicationBuilder builder)
        {
            using (var applicationservices = builder.ApplicationServices.CreateScope())
            {
                var context = applicationservices.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();
                //Category
                if (!context.Categories.Any())
                {
                    var categories = new List<Category>()
                    {
                        new Category()
                        {
                            Name = "MSI",
                            Description = "C1"
                        },
                         new Category()
                        {
                            Name = "ASUS",
                            Description = "C2"
                        },
                          new Category()
                        {
                            Name = "GIGABYTE",
                            Description = "C3"
                        },
                            new Category()
                        {
                            Name = "PYN",
                            Description = "C4"
                        },
                         new Category()
                        {
                            Name = "PYN",
                            Description = "C4"
                        }
                    };
                    context.Categories.AddRange(categories);
                    context.SaveChanges();

                }

                //Product
                if (!context.Products.Any())
                {
                    var Products = new List<Product>()
                    {
                        //VGA
                        new Product()
                        {
                            Name = "VGA ASUS RTX 2060 EVO 6GB",
                            Description = "DUAL-RTX2060-O6G-EVO",
                            Price = 200,
                            ImageURL="https://product.hstatic.net/1000026716/product/01_2332cba6be5243a7b5fd9dca236be128.png",
                            ProductType = ProductType.VGA,
                            CategoryId=1

                        },
                        new Product()
                        {
                            Name = "VGA MSI RTX 3070 Ventus Plus 3X 8G",
                            Description = "RTX3070-VENTUS-3X-8G",
                            Price = 250,
                            ImageURL="https://product.hstatic.net/1000026716/product/1024_398ca947c100419a9b00c5150c6f7149.png",
                            ProductType = ProductType.VGA,
                            CategoryId=1

                        },
                        new Product()
                        {
                            Name = "VGA Gigabyte GTX 1660 SUPER 6GB",
                            Description = "GV-N166SOC-6GD",
                            Price = 350,
                            ImageURL="https://product.hstatic.net/1000026716/product/pny-geforce-gtx-1650-4gb-gddr6-single-fan_683096812008461a9fab2bec9ec96027.jpg",
                            ProductType = ProductType.VGA,
                            CategoryId=1

                        },
                        new Product()
                        {
                            Name = "VGA PNY GTX 1650 4GB",
                            Description = "VCG16504D6SFMPB",
                            Price = 350,
                            ImageURL="https://product.hstatic.net/1000026716/product/pny-geforce-gtx-1650-4gb-gddr6-single-fan_683096812008461a9fab2bec9ec96027.jpg",
                            ProductType = ProductType.VGA,
                            CategoryId=1

                        },

                        //RAM

                    };
                    context.Products.AddRange(Products);
                    context.SaveChanges();
                }


            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder builder)
        {
            using (var applicationservices = builder.ApplicationServices.CreateScope())
            {
                #region Role

                var roleManager =
                    applicationservices.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                
                if(! await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }

                #endregion

                #region User

                var userManager =
                    applicationservices.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                
                if(await userManager.FindByEmailAsync("admin@admin.com") == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        Email = "admin@admin.com",
                        EmailConfirmed = true,
                        FullName = "Admin User",
                        UserName = "Admin"
                    };
                    await userManager.CreateAsync(newAdminUser,"@Dmin123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);

                    if (await userManager.FindByEmailAsync("user@user.com") == null)
                    {
                        var newOriginalUser = new ApplicationUser()
                        {
                            Email = "user@user.com",
                            EmailConfirmed = true,
                            FullName = "Original User",
                            UserName = "User"
                        };
                        await userManager.CreateAsync(newOriginalUser, "@User123");
                        await userManager.AddToRoleAsync(newOriginalUser, UserRoles.User);
                    }                    
                }

                #endregion

            }
        }
    }
}
