using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models.IRepositories
{
    public interface IPatientRepository
    {
        Patient Add(Patient patient);
        Patient GetPatient(int PatientID);
        Patient GetPatientByCitizenId(int CitizenID);
        IEnumerable<Patient> GetAllPatients();
        Patient Delete(int PatientID);
        Patient GetMaxPatient();
    }
}
