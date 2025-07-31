using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT1.NewFolder
{
    internal class Patient
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

      
        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
        public List<Appointment> Appointments { get; set; } = new();
    }
}
