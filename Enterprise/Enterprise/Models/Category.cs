using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebEnterpriseProject.Models
{
  public class Category
  {
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "CategoryName cannot be null ...")]
    [StringLength(255)]
   	public string CategoryName { get; set; }
    public string Description { get; set; }
    public List<Post> Posts { get; set; }
  }
}