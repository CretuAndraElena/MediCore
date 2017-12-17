using DataDomain;
using DataPersistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Repositorys
{
    public class PatientRepository : IRepository<Patient>
    {
        private readonly IDataBaseContext _databaseService;

        public PatientRepository(IDataBaseContext database)
        {
            _databaseService = database;
        }
        public DbSet<Patient> GetAll()
        {
            return _databaseService.Patients;

        }

        public Patient GetById(Guid id)
        {
            return _databaseService.Patients.FirstOrDefault(patient => patient.Id == id);
        }

        public void Add(Patient patient)
        {
            _databaseService.Patients.Add(patient);
            _databaseService.SaveChanges();
        }

        public void Update(Patient patient)
        {
            _databaseService.Patients.Update(patient);
            _databaseService.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var patient = GetById(id);
            _databaseService.Patients.Remove(patient);
            _databaseService.SaveChanges();
        }

        public int SaveChanges()
        {
            return _databaseService.SaveChanges();
        }
    }
}
