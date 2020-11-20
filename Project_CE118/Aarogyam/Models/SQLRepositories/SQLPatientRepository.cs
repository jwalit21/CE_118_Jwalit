using Aarogyam.Models.IRepositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models.SQLRepositories
{
    public class SQLPatientRepository : IPatientRepository
    {
        private readonly AppDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public SQLPatientRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Patient Add(Patient patient)
        {
            context.Patients.Add(patient);
            context.SaveChanges();
            return patient;
        }

        public Patient Delete(int PatientID)
        {
            Patient patient = context.Patients.Find(PatientID);
            if (patient != null)
            {
                context.Patients.Remove(patient);
                context.SaveChanges();
            }
            return patient;
        }

        Patient IPatientRepository.GetMaxPatient()
        {
            var max_patient_id = context.Patients.Max(user => user.PatientId);
            var user_max = context.Patients.Where(user => user.PatientId == max_patient_id).FirstOrDefault();
            return user_max;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return context.Patients;
        }

        public Patient GetPatient(int PatientID)
        {
            return context.Patients.FirstOrDefault(m => m.PatientId == PatientID);
        }

        public Patient GetPatientByCitizenId(int CitizenID)
        {
            return context.Patients.FirstOrDefault(m => m.CitizenId == CitizenID);
        }
    }
}
