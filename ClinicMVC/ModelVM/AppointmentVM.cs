using ClinicMVC.Helpers;

namespace ClinicMVC.ModelVM
{
    public class AppointmentVM
    {
        public int id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string PatientName { get; set; }
        public string DoctorName { get; set; }

        public string RawStatus { get; set; } = null!;
        public string Status =>
            RawStatus == Statuses.Scheduled.ToString() && AppointmentDate < DateTime.Now
            ? "Cancelled" : RawStatus;

    }
}
