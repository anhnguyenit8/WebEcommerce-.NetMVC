using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEcommerce.Controllers.Cart;

namespace WebEcommerce.Data.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart { get; set; }
        public double ShoppingCartTotal { get; set; }
    }
}
