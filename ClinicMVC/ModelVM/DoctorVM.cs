using ClinicMVC.Models;

namespace ClinicMVC.ModelVM
{
    public class DoctorVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public string Speciality { get; set; }

        public List<AppointmentVM> Appointments { get; set; } = new();
    }
}
