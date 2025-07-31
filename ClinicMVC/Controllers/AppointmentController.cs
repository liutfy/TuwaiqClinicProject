using ClinicMVC.Models;
using ClinicMVC.ModelVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ClinicMVC.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {

        public ClinicContext context;

        public AppointmentController(ClinicContext context)
        {
            this.context = context;

        }


        public IActionResult Index()
        {

            var appointmentVMs = context.Appointments
                               .Include(a => a.Doctor)
                               .Include(a => a.Patient)
                               .ToList()
                               .Select(a => a.ToAppointmentVM())
                               .OrderByDescending(a => a.AppointmentDate)
                               .ToList();

            return View(appointmentVMs);
        }

        public IActionResult Details(int id)
        {

            var Appointment = context.Appointments
                                .Include(a => a.Doctor)
                                .Include(a => a.Patient)
                                .FirstOrDefault(p => p.id == id);
            if (Appointment == null)
            {
                return NotFound();
            }

            var vm = Appointment.ToAppointmentVM();
            return View(vm);
        }


        public IActionResult Create(int PatientID)
        {
            var vm = new CreateAppointmentVM
            {
                PatientID = PatientID,
                Doctors = context.Doctors.Select(d => new SelectListItem
                {
                    Value = d.id.ToString(),
                    Text = d.name
                }).ToList(),

            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateAppointmentVM newAppointment)
        {

            if (!ModelState.IsValid)
            {
                newAppointment.Doctors = context.Doctors.Select(d => new SelectListItem
                {
                    Value = d.id.ToString(),
                    Text = d.name
                }).ToList();


                return View(newAppointment);
            }

            var appointment = newAppointment.toAppointment();
            context.Appointments.Add(appointment);
            context.SaveChanges();

            return RedirectToAction("Details", "Patient", new { id = newAppointment.PatientID });
        }


        public IActionResult Delete(int id)
        {
            var Appointment = context.Appointments.FirstOrDefault(p => p.id == id);
            if (Appointment == null)
            {
                return NotFound();
            }

            context.Appointments.Remove(Appointment);
            context.SaveChanges();
            return Ok();
        }
    }
}
    