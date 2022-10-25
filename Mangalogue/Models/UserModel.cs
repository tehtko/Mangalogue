using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Mangalogue.Models
{
    public class UserModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please provide a valid Username")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters.")]
        public string? Username { get; set; }

        public string? Email { get; set; }

        [Required(ErrorMessage = "Please provide a valid password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be more than 6 characters")]
        public string? Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string? ConfirmPassword { get; set; }
    }
}
