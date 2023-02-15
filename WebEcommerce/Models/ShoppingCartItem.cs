using System;
using System.Threading.Tasks;
using WebEcommerce.Base;

namespace WebEcommerce.Models
{
    public class ShoppingCartItem: IBaseEntity
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }

        /*public static implicit operator Task<object>(ShoppingCartItem v)
        {
            throw new NotImplementedException();
        }*/
    }
}
