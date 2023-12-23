// Projeto: Sceptrum Project
// Autor: Diego Hartwig
using System.ComponentModel.DataAnnotations;

namespace SceptrumProject.API.DTO
{
    public class RegisterDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }
    }
}
