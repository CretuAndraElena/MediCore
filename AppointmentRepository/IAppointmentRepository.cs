using DataDomain;
using Microsoft.EntityFrameworkCore;
using System;

namespace AppointmentRepositorys
{
    public interface IAppointmentRepository
    {
        DbSet<Appointment> GetAll();
        Appointment GetById(Guid id);
        void Add(Appointment product);
        void Update(Appointment product);
        void Delete(Guid id);
        int SaveChanges();
    }
}
