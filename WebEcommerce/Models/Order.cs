using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebEcommerce.Base;

namespace WebEcommerce.Models
{
    public class Order : IBaseEntity
    {
        public Order()
        { 
            OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public ICollection<OrderItem> OrderItems {get; set;}
    }
}
