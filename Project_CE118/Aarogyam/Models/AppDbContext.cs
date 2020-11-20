using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aarogyam.Models;
using Task = Aarogyam.Models.Task;
using Aarogyam.Models.ViewModels;

namespace Aarogyam.Models
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);

            builder.Entity<CitizenHospital>().HasKey(ch => new { ch.CitizenId });
            builder.Entity<ForgotPasswordViewModel>().HasNoKey();
            builder.Entity<ResetPasswordViewModel>().HasNoKey();

            builder.Entity<RequestPatient>().Property(a => a.Id).ValueGeneratedNever();

            //            builder.Entity<CitizenHospital>().HasOne<ApplicationUser>(usr => usr.Hospital).WithMany(f => f.)

            //builder.Entity<CitizenHospital>().
            //      HasOne<ApplicationUser>(s => s.applicationUser).
            //      WithMany(g => g.citizenHospitals).
            //      HasForeignKey(s => s.HospitalId);
        }

        public DbSet<Advisory> Advisories { get; set; }
        public DbSet<CitizenHospital> CitizenHospitals { get; set; }
        public DbSet<CovidData> CovidDatas { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<RequestPatient> RequestPatients { get; set; }
        public DbSet<Aarogyam.Models.ViewModels.RegisterCitizen> RegisterCitizen { get; set; }
        public DbSet<Aarogyam.Models.ViewModels.RegisterHospital> RegisterHospital { get; set; }
        
    }
}
