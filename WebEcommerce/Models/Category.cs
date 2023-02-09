using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebEcommerce.Models
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]  
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 

        //Navigational Property
        public ICollection<Product> Products { get; set; }

    }
}
