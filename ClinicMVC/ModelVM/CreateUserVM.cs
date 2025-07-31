using ClinicMVC.Helpers;
using Microsoft.Extensions.Logging.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace ClinicMVC.ModelVM
{
    public class CreateUserVM
    {
        

        public string Email { get; set; } = null;

        [DataType(DataType.Password)]
        public string Password { get; set; } = null;
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password is not the same")]
        public string ConfirmedPassword { get; set; } = null;
        [EnumDataType(typeof(AppRoles))]
        public String Role { get; set; } = null;

        [Display(Name = "Profile Picture")]
        public IFormFile? ProfilePicture { get; set; }


    }
}
