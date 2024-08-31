using System.ComponentModel.DataAnnotations;

namespace HR_Management.WebMvc.Models.Authentication
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Re Password")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
    }
}
