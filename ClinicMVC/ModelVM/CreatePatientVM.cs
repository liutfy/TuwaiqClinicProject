using ClinicMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace ClinicMVC.ModelVM
{
    public class CreatePatientVM
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [RegularExpression("05\\d{8}", ErrorMessage = "Phone number must be in format 05xxxxxxxx")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        [Display(Name = "National Id")]
        public string NationalId { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now.AddYears(-20);
        public string Gender { get; set; }


        public Patient ToPatient()
        {
            return new Patient
            {
                FullName = FullName,
                PhoneNumber = PhoneNumber,
                Email = Email,
                NationalId = NationalId,
                DateOfBirth = DateOfBirth,
                Gender = Gender
            };
        }
    }
}
