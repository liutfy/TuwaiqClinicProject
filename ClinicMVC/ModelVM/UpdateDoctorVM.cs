using ClinicMVC.Controllers;
using ClinicMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace ClinicMVC.ModelVM
{
    public class UpdateDoctorVM
    {
        public int id { get; set; }

        [Display(Name = "Full Name")]
        public string name { get; set; }

        [Display(Name = "Speciality")]
        public string Speciality { get; set; }

        public void ToDoctor(Doctor d)
        {

            
            d.name = name;
            d.Speciality = Speciality;
            
        }


    }
}
