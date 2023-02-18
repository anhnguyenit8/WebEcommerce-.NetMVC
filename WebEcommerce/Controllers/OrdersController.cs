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
        private readonly IOrderServices _orderServices;

        public OrdersController(IProductServices services,ShoppingCart shoppingCart, IOrderServices orderServices)
        {
            _services = services;
            _shoppingCart = shoppingCart;
            _orderServices = orderServices;
        }

        public async Task<IActionResult> Index()
        {
            string userId = "";
            var order = await _orderServices.GetOrderByUserIdAsync(userId);
            return View(order);
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

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var item = await _services.GetByIdAsync(id);
            if (item != null)
            {
                await _shoppingCart.RemoveItemFromShoppingCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = "";
            await _orderServices.StoreOrderAsync(items, userId); //// Bug Here
            _shoppingCart.ClearShoppingCart();
            return View("CompleteOrder");
        }
    }
}
