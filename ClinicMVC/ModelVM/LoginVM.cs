using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ClinicMVC.ModelVM
{
    public class LoginVM
    {
        [EmailAddress]
        public String Email { get; set; } = null;
        [DataType(DataType.Password)]
        public String Password { get; set; } = null;
    }
}
