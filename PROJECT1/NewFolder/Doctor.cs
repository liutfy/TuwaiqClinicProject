using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT1.NewFolder
{
    internal class Doctor
    {
        public int id { get; set; }
        public string Name { get; set; }
        public ICollection<Patient> Patients { get; set; } = new List<Patient>();
       

    }
}
