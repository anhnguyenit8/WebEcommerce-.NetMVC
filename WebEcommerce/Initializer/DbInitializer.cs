﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using WebEcommerce.Data;
using WebEcommerce.Models;

namespace WebEcommerce.Initializer
{
    public class DbInitializer
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

                        }
                    };
                    context.Products.AddRange(Products);
                    context.SaveChanges();
                }


            }
        }
    }
}
