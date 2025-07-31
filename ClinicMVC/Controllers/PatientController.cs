using ClinicMVC.Models;
using ClinicMVC.ModelVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicMVC.Controllers
{
        [Authorize]
        public class PatientController : Controller
        {

            public ClinicContext context;

            public PatientController(ClinicContext context)
            {
                this.context = context;
           
            }


            public IActionResult Index()
            {

                var patients = context.Patients
                                        .Select(p => p.ToPatientVM())
                                        .ToList();


                return View(patients);
            }

            public IActionResult Details(int id)
            {

                var patient = context.Patients
                                 //.Include(p => p.Appointments)
                                 //.ThenInclude(a => a.Doctor)
                                 .FirstOrDefault(p => p.id == id);
                if (patient == null)
                {
                    return NotFound();
                }

                var vm = patient.ToPatientVM();
                return View(vm);
            }


            public IActionResult Create()
            {
                var vm = new CreatePatientVM();
                return View(vm);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(CreatePatientVM newPatient)
            {

                if (!ModelState.IsValid)
                {
                    return View(newPatient);
                }

                var patient = newPatient.ToPatient();
                context.Patients.Add(patient);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            public IActionResult Update(int id)
            {
                var patient = context.Patients.FirstOrDefault(p => p.id == id);
                if (patient == null)
                {
                    return NotFound();
                }

                var vm = patient.ToPatientUpdateVM();
                return View(vm);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Update(int id, UpdatePatientVM updatedPatient)
            {

                if (!ModelState.IsValid)
                {
                    return View(updatedPatient);
                }

                var existingPatient = context.Patients.FirstOrDefault(p => p.id == id);
                if (existingPatient == null)
                {
                    return NotFound();
                }

                updatedPatient.ToPatient(existingPatient);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            public IActionResult Delete(int id)
            {
                var patient = context.Patients.FirstOrDefault(p => p.id == id);
                if (patient == null)
                {
                    return NotFound();
                }

                context.Patients.Remove(patient);
                context.SaveChanges();
                return Ok();
            }
        }
    }

