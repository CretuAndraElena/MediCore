using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}