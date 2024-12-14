using System.ComponentModel.DataAnnotations;

namespace Demo1.ViewModel
{
    public class RegisterStudentUserModelView
    {
        [Required]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirmed { get; set; }
        [Required]
        public string Faculty { get; set; }
        [MaxLength(12)]
        public string? Address { get; set; }

    }
}
