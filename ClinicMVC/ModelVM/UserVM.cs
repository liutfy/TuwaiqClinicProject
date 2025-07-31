using ClinicMVC.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ClinicMVC.ModelVM
{
    public class UserVM
    {


            public string Email { get; set; } 

            public String Role { get; set; }
            //public IFormFile? ProfilePicture { get; set; }
            public string? ImageBase64 { get; set; }




    }
}
