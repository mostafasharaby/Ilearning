using System.ComponentModel.DataAnnotations;

namespace Demo1.ViewModel
{
    public class RegisterUserViewModel
    {
        [Required]
        public string UserName { get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirmed { get; set; }

        public string Address { get; set; }
    }
}
