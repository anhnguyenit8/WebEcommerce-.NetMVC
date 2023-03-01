using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebEnterpriseProject.Models
{
  public class Department
  {
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Department Name cannot be null ...")]
    [StringLength(255)]
   	public string DepartmentName { get; set; }
    public List<User> Users { get; set; }
  }
}
