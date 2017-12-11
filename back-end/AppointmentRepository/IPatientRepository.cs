using DataDomain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Repositorys
{
    public interface IPatientRepository
    {
        DbSet<Patient> GetAll();
        Patient GetById(Guid id);
        void Add(Patient patient);
        void Update(Patient patient);
        void Delete(Guid id);
        int SaveChanges();
    }
}