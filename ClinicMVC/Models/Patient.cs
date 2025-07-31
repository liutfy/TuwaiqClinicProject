using System.ComponentModel.DataAnnotations;
using ClinicMVC.ModelVM;

namespace ClinicMVC.Models
{
    public class Patient
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
        public List<Appointment> Appointments { get; set; } = new();

        public PatientVM ToPatientVM()
        {
            return new PatientVM
            {
                id = id,
                FullName = FullName,
                PhoneNumber = PhoneNumber,
                Email = Email,
                NationalId = NationalId,
                DateOfBirth = DateOfBirth,
                Gender = Gender,
                //Appointments = Appointments.Select(a => a.ToAppointmentVM()).ToList(),
            };
        }

        public UpdatePatientVM ToPatientUpdateVM()
        {
            return new UpdatePatientVM
            {
                id = id,
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
