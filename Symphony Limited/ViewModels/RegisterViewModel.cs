using System.ComponentModel.DataAnnotations;

namespace Symphony_Limited.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords does not match")]
        public required string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
