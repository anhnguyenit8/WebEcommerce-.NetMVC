using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebEcommerce.Data.Cart;
using WebEcommerce.Services;

namespace WebEcommerce.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProductServices _services;
        private readonly ShoppingCart _shoppingCart;
        public OrdersController(IProductServices services,ShoppingCart shoppingCart)
        {
            _services = services;
            _shoppingCart = shoppingCart;
        }

        //View Shopping Cart
        public IActionResult ShoppingCart()
        {

            var item = _shoppingCart.GetShoppingCartItems();
            ViewBag.Total = _shoppingCart.GetShoppingCartTotal();
            return View(item);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var item =  await _services.GetByIdAsync(id);
            if (item != null)
            {
                await _shoppingCart.AddItemToShoppingCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
