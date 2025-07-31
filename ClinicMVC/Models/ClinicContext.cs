using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicMVC.Helpers;

namespace ClinicMVC.Models
{
    public class ClinicContext : IdentityDbContext<AppUsers>
    {

        public DbSet<Doctor> Doctors { get; set; } = null!;

        public DbSet<Patient> Patients { get; set; } = null!;

        public DbSet<Appointment> Appointments { get; set; } = null!;

        public DbSet<AppUsers> Users {  get; set; } = null!;



        public ClinicContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("GetDate()");

            //modelBuilder.Entity<Appointment>()
            //    .HasData(
            //        new Appointment { id = 1, AppointmentDate = new DateTime(2025, 8, 1, 17, 0, 0), DoctorID = 1, Status = "Scheduled" },
            //        new Appointment { id = 2, AppointmentDate = new DateTime(2025, 7, 25, 17, 0, 0), DoctorID = 1, Status = "Completed" },
            //        new Appointment { id = 3, AppointmentDate = new DateTime(2025, 8, 5, 17, 0, 0), DoctorID = 1, Status = "Scheduled" }
            //    );

            modelBuilder.Entity<AppUsers>(b => b.ToTable("Users"));
            modelBuilder.Entity<IdentityRole>(b => b.ToTable("Roles"));
            modelBuilder.Entity<IdentityRoleClaim<string>>(b => b.ToTable("RoleClaims"));
            modelBuilder.Entity<IdentityUserClaim<string>>(b => b.ToTable("UserClaims"));
            modelBuilder.Entity<IdentityUserRole<string>>(b => b.ToTable("UserRoles"));
            modelBuilder.Entity<IdentityUserToken<string>>(b => b.ToTable("UserTokens"));
            modelBuilder.Entity<IdentityUserLogin<string>>(b => b.ToTable("UserLogins"));


            modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole { Id = "7f04c9e3-ed37-4f63-88cf-b512b6fd61f6", ConcurrencyStamp = "7f04c9e3-ed37-4f63-88cf-b512b6fd61f6", Name = AppRoles.Admin.ToString(), NormalizedName = AppRoles.Admin.ToString().ToUpper() },
                    new IdentityRole { Id = "2c23dff5-efc4-4e34-945f-1a2f29da0231", ConcurrencyStamp = "2c23dff5-efc4-4e34-945f-1a2f29da0231", Name = AppRoles.Receptionist.ToString(), NormalizedName = AppRoles.Receptionist.ToString().ToUpper() },
                    new IdentityRole { Id = "59fa9387-3202-4e97-aa7f-22a107c6e4a1", ConcurrencyStamp = "59fa9387-3202-4e97-aa7f-22a107c6e4a1", Name = AppRoles.Doctor.ToString(), NormalizedName = AppRoles.Doctor.ToString().ToUpper() }
                );
        }

    }
    }

