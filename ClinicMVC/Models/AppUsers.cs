using ClinicMVC.ModelVM;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicMVC.Models
{
    public class AppUsers : IdentityUser
    {
       
            public byte[]? ProfilePicture { get; set; }
            //[NotMapped]
            //public string ImageBase64 => ProfilePicture != null
            //    ? $"data:image/jpeg;base64,{Convert.ToBase64String(ProfilePicture)}"
            //    : null;


        public UserVM ToUserVM(String Role)
        {
            return new UserVM
            {
                Email = Email,
                Role = Role,
                ImageBase64 = ProfilePicture != null
                    ? $"data:image/jpeg;base64,{Convert.ToBase64String(ProfilePicture)}"
                    : null
            };
        }
    }
}
