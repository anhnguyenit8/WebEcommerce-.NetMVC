using System.Collections.Generic;
using System.Threading.Tasks;
using WebEcommerce.Models;

namespace WebEcommerce.Services
{
    public interface IOrderServices
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items,string userId);
        Task<List<Order>> GetOrderAndRoleByUserIdAsync(string userId,string role);
       
    }
}
