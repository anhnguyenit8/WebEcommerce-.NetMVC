using System.ComponentModel.DataAnnotations;

namespace WebEcommerce.ViewModels
{
    public class LoginVM
    {

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "This field is reqired!")]
        [DataType(DataType.EmailAddress)]

        public string EmailAddress { get; set; }
        
        [Required(ErrorMessage = "This field is reqired!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
