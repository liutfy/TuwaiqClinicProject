using ClinicMVC.Models;
using ClinicMVC.ModelVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ClinicMVC.Controllers
{

    [Authorize]
    public class DoctorController : Controller

    {
       
        public ClinicContext context;

        public DoctorController(ClinicContext context)
        {
            this.context = context;
        }

       
        public IActionResult Index(DoctorFilterVM filter)
        {
            var doctors = context.Doctors
                                    .Where(d => filter.id == null || d.id == filter.id)
                                    .Where(d => filter.name == null || d.name.Contains(filter.name))
                                    .Where(d => filter.Speciality == null || d.Speciality == filter.Speciality)
                                    .Select(d => d.ToDoctorVM())
                                    .ToList();

            var vm = new DoctorFilterListVM
            {
                data = doctors,
                filter = filter
            };
            
            return View(vm);
        }

        public IActionResult Details(int id)
        {
            //var doctor = context.Doctors.FirstOrDefault(p => p.id == id);
            var doctor = context.Doctors
            .Include(d => d.Appointments) 
            .FirstOrDefault(p => p.id == id);

            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor.ToDoctorVM());
        }
        public IActionResult Create()
        {
            
            return View(new CreateDoctorVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateDoctorVM newD)
        {

            if (!ModelState.IsValid)
            {
                return View(newD);
            }
            context.Doctors.Add(newD.ToDoctor());
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            var doctor = context.Doctors.FirstOrDefault(p => p.id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor.ToUpdateDoctorVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, UpdateDoctorVM updatedDoctor)
        {

            if (!ModelState.IsValid)
            {
                return View(updatedDoctor);
            }

            var existingDoctor = context.Doctors.FirstOrDefault(p => p.id == id);
            if (existingDoctor == null)
            {
                return NotFound();
            }

            updatedDoctor.ToDoctor(existingDoctor);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var doctor = context.Doctors.FirstOrDefault(d => d.id == id);
            if (doctor == null)
            {
                return NotFound();
            }
            context.Doctors.Remove(doctor);
            context.SaveChanges();
            return Ok();
        }
    }
}
