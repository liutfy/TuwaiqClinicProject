using ClinicMVC.ModelVM;

namespace ClinicMVC.Models
{
    public class Appointment
    {
        public int id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime AppointmentDate { get; set; }

        public int DoctorID { get; set; }

        public int PatientID { get; set; }

        public string Status { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

        public AppointmentVM ToAppointmentVM() {

            return new AppointmentVM {
                id = id,
                CreatedAt = CreatedAt,
                AppointmentDate = AppointmentDate,
                DoctorName = Doctor.name,
                PatientName = Patient.FullName,
                RawStatus = Status};
        }


    }
}
