using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebEcommerce.Base;

namespace WebEcommerce.Models
{
    public class Category: IBaseEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]  
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [StringLength(20,ErrorMessage ="This {0} is spesific between{2},{1}",MinimumLength =5)]
        [Display(Name ="Category Name")]

        public string Name { get; set; }
        public string Description { get; set; } 

        //Navigational Property
        public ICollection<Product> Products { get; set; }

    }
}
