using System.ComponentModel.DataAnnotations;

namespace ClinicMVC.Helpers

{
    public enum Specialties
    {
        Dermatology,

        [Display(Name = "General Surgery")]
        GeneralSurgery,

        Cardiology,

        Neurology, 

        Pathology
    }
}
