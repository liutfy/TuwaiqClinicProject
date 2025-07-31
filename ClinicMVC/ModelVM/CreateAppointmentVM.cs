using ClinicMVC.Helpers;
using ClinicMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ClinicMVC.ModelVM
{
    public class CreateAppointmentVM
    {
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

        [Display(Name = "Patient")]
        public int PatientID {  get; set; }
        [Display(Name = "Doctor")]
        public int DoctorID { get; set; }
        public List<SelectListItem> Doctors { get; set; } = new();
   
        public Appointment toAppointment()
        {
            return new Appointment
            {
                AppointmentDate = AppointmentDate,
                PatientID = PatientID,
                DoctorID = DoctorID,
                Status = "Scheduled"
            };
        }

    }
}

