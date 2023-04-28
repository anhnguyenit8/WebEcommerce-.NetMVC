using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using WebEcommerce.Data;
using WebEcommerce.Models;

namespace WebEcommerce.Controllers.Cart
{

    public class ShoppingCart
    {
        private readonly ApplicationDbContext _context;
        public string ShoppingCartId { get; set; }
        public ShoppingCart(ApplicationDbContext context)
        {
            _context = context;
        }
        public static ShoppingCart GetShoppingCart(IServiceProvider service)
        {

            ISession session = service.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            var context = service.GetRequiredService<ApplicationDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };

        }


        //Get All Items in Shopping Cart
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return _context.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId).Include(x => x.Product).ToList();

        }

        //Calculate Total Amount in Shopping Cart Item
        public double GetShoppingCartTotal()
           => _context.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId).Select(x => x.Product.Price * x.Amount).Sum();

        public int GetShoppingCartTotalAmount()
            => _context.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId).Select(x => x.Amount).Sum();

        //Adding Item to Shopping Cart
        public async Task AddItemToShoppingCart(Product product)
        {
            var shoppingCartItem = await _context.ShoppingCartItems.FirstOrDefaultAsync(x =>
            x.ShoppingCartId == ShoppingCartId && x.Product.Id == product.Id);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };
                await _context.ShoppingCartItems.AddAsync(shoppingCartItem);
                await _context.SaveChangesAsync();
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            await _context.SaveChangesAsync();
        }

        //Remove Item form Shopping Cart
        public async Task RemoveItemFromShoppingCart(Product product)
        {
            var shoppingCartItem = await _context.ShoppingCartItems.FirstOrDefaultAsync(x =>
            x.ShoppingCartId == ShoppingCartId && x.Product.Id == product.Id);
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
                await _context.SaveChangesAsync();
            }
        }

        public void ClearShoppingCart()
        {
            var items = _context.ShoppingCartItems.Where(x => x.ShoppingCartId ==
            ShoppingCartId).ToList();
            _context.ShoppingCartItems.RemoveRange(items);
            _context.SaveChanges();
        }
    }
}
