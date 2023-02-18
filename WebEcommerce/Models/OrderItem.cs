using System.ComponentModel.DataAnnotations.Schema;
using WebEcommerce.Base;

namespace WebEcommerce.Models
{
    public class OrderItem: IBaseEntity
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        //Navigation Property
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
