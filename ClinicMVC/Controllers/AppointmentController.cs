using ClinicMVC.Models;
using ClinicMVC.ModelVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ClinicMVC.Controllers
{
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
            .Select(a => new AppointmentVM
            {
                id = a.id,
                DoctorName = a.Doctor.name,
                PatientName = a.Patient.FullName,
                AppointmentDate = a.AppointmentDate,
                RawStatus = a.Status
            })
            .OrderByDescending(a => a.AppointmentDate)
            .ToList();

            return View(appointmentVMs);
        }

            //public IActionResult Details(int id)
            //{

            //    var Appointments = context.Appointments
            //                     //.Include(p => p.Appointments)
            //                     //.ThenInclude(a => a.Doctor)
            //                     .FirstOrDefault(p => p.id == id);
            //    if (patient == null)
            //    {
            //        return NotFound();
            //    }

            //    var vm = patient.ToPatientVM();
            //    return View(vm);
            //}


            public IActionResult Create()
            {
            var vm = new CreateAppointmentVM
            {
                Doctors = context.Doctors.Select(d => new SelectListItem
                {
                    Value = d.id.ToString(),
                    Text = d.name
                }).ToList(),

                Patients = context.Patients.Select(p => new SelectListItem
                {
                    Value = p.id.ToString(),
                    Text = p.FullName
                }).ToList()
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

                newAppointment.Patients = context.Patients.Select(p => new SelectListItem
                {
                    Value = p.id.ToString(),
                    Text = p.FullName
                }).ToList();

                return View(newAppointment);
            }

            var appointment = newAppointment.toAppointment();
            context.Appointments.Add(appointment);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }

            //public IActionResult Update(int id)
            //{
            //    var patient = context.Patients.FirstOrDefault(p => p.id == id);
            //    if (patient == null)
            //    {
            //        return NotFound();
            //    }

            //    var vm = patient.ToPatientUpdateVM();
            //    return View(vm);
            //}

            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public IActionResult Update(int id, UpdatePatientVM updatedPatient)
            //{

            //    if (!ModelState.IsValid)
            //    {
            //        return View(updatedPatient);
            //    }

            //    var existingPatient = context.Patients.FirstOrDefault(p => p.id == id);
            //    if (existingPatient == null)
            //    {
            //        return NotFound();
            //    }

            //    updatedPatient.ToPatient(existingPatient);
            //    context.SaveChanges();
            //    return RedirectToAction(nameof(Index));
            //}

            //public IActionResult Delete(int id)
            //{
            //    var patient = context.Patients.FirstOrDefault(p => p.id == id);
            //    if (patient == null)
            //    {
            //        return NotFound();
            //    }

            //    context.Patients.Remove(patient);
            //    context.SaveChanges();
            //    return Ok();
            //}
        }
    