using ClinicMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace ClinicMVC.ModelVM
{
    public class PatientVM
    {
        public int id { get; set; }
        public string FullName { get; set; }
        [RegularExpression("05\\d{8}", ErrorMessage = "Phone number must be in format 05xxxxxxxx")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string NationalId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Gender { get; set; }
        public int Age => Convert.ToInt32((DateTime.Today - DateOfBirth).TotalDays / 365);
        public List<Appointment> Appointments { get; set; } = new();
    }
}
