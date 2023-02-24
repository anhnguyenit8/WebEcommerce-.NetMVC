using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebEcommerce.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "This field is reqired!")]
        [DataType(DataType.EmailAddress)]

        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "This field is reqired!")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [Required(ErrorMessage = "This field is reqired!")]
        [Compare(nameof(Password), ErrorMessage = "Not Identical!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
