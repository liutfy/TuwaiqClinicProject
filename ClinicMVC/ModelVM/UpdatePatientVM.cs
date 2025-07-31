using ClinicMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace ClinicMVC.ModelVM
{
    public class UpdatePatientVM
    {
        public int id { get; set; }

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


        public void ToPatient(Patient patient)
        {
            patient.FullName = FullName;
            patient.PhoneNumber = PhoneNumber;
            patient.Email = Email;
            patient.NationalId = NationalId;
            patient.DateOfBirth = DateOfBirth;
            patient.Gender = Gender;
            
        }
    }
}
