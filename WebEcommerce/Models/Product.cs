using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebEcommerce.Base;
using WebEcommerce.Data.Enums;


namespace WebEcommerce.Models
{
    public class Product: IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public ProductType ProductType { get; set; }
        public string Specifications { get; set; }
        public string Introduce { get; set; }

        //Navigational Property
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

    }
}
