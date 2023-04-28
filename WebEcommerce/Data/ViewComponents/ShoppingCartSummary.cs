using Microsoft.AspNetCore.Mvc;
using WebEcommerce.Controllers.Cart;

namespace WebEcommerce.Data.ViewComponents
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _cart;
        public ShoppingCartSummary(ShoppingCart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke()
        {
            var item = _cart.GetShoppingCartTotalAmount();
            ViewBag.Total = _cart.GetShoppingCartTotal();
            return View(item);
        }
    }
}
