using ClinicMVC.ModelVM;

namespace ClinicMVC.Models
{
    public class Doctor
    {
        public int id { get; set; }
        public string name { get; set; }
        public string Speciality { get; set; }

        public List<Appointment> Appointments { get; set; } = new();

        public DoctorVM ToDoctorVM()
        {
            return new DoctorVM { 
                id = id,
                name = name, 
                Speciality = Speciality ,
                Appointments = Appointments.Select(a => a.ToAppointmentVM()).ToList(),
            };
        }
        //public CreateDoctorVM ToCreateDoctorVM()
        //{
        //    return new CreateDoctorVM { 
        //        name = name,
        //        Speciality = Speciality };
        //}

        public UpdateDoctorVM ToUpdateDoctorVM()
        {
            return new UpdateDoctorVM {
                id = id, 
                name = name, 
                Speciality = Speciality };
        }
    }
}
