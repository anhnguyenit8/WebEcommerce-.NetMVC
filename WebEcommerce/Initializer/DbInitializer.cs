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
                            Name = "C1",
                            Description = "C1"
                        },
                         new Category()
                        {
                            Name = "C2",
                            Description = "C2"
                        },
                          new Category()
                        {
                            Name = "C3",
                            Description = "C3"
                        },
                            new Category()
                        {
                            Name = "C4",
                            Description = "C4"
                        },
                              new Category()
                        {
                            Name = "C5",
                            Description = "C5"
                        },
                    };
                    context.Categories.AddRange(categories);
                    context.SaveChanges();

                }

                //Product
                if (!context.Products.Any())
                {
                    var Products = new List<Product>()
                    {
                        new Product()
                        {
                            Name = "P1",
                            Description = "D1",
                            Price= 200,
                            ImageURL="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSleSktbNDRE9njorB2zT3TnYPPI3qjYVl8uw&usqp=CAU",
                            ProductType = ProductType.Red,CategoryId=1

                        },
                        new Product()
                        {
                            Name = "P2",
                            Description = "D2",
                            Price= 250,
                            ImageURL="https://antien.vn/uploads/product/dong-ho-thong-minh-fitbit-versa-2-chinh-hang_1604387316.jpg",
                            ProductType = ProductType.Green,CategoryId=2

                        },
                        new Product()
                        {
                            Name = "P3",
                            Description = "D3",
                            Price= 300,
                            ImageURL="https://thegioigiaythethao.vn/images/Upload/images/dong-ho-puma/01-dong-ho-deo-tay-nu-puma-reset-v2/dong-ho-deo-tay-nu-puma-reset-v2-(1).jpg",
                            ProductType = ProductType.Blue,CategoryId=3

                        },
                        new Product()
                        {
                            Name = "P4",
                            Description = "D4",
                            Price= 350,
                            ImageURL="https://thegioigiaythethao.vn/images/Upload/images/dong-ho-puma/01-dong-ho-deo-tay-nu-puma-reset-v2/dong-ho-deo-tay-nu-puma-reset-v2-(1).jpg",
                            ProductType = ProductType.Yellow,CategoryId=4

                        }
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
                
                if(! await roleManager.RoleExistsAsync(UserRoles.Role_Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Role_Admin));
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.Role_User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Role_User));
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
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Role_Admin);

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
                        await userManager.AddToRoleAsync(newOriginalUser, UserRoles.Role_User);
                    }
                }

                #endregion

            }
        }
    }
}
