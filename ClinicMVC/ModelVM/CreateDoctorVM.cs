using System.ComponentModel.DataAnnotations;
using ClinicMVC.Models;
using ClinicMVC.Controllers;

namespace ClinicMVC.ModelVM
{
    public class CreateDoctorVM
    {
        [Display(Name = "Full Name")]
        public string name { get; set; }

        [Display(Name = "Speciality")]
        public string Speciality { get; set; }

        public Doctor ToDoctor()
        {
            return new Doctor
            { 
                name = name,
                Speciality = Speciality
            };
        }

    }
}
