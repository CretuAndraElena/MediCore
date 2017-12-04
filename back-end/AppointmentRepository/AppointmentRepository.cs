using DataDomain;
using DataPersistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AppointmentRepositorys
{
    public class AppointmentRepository: IAppointmentRepository
    {
        private readonly IDataBaseContext _databaseService;

        public AppointmentRepository(IDataBaseContext database)
        {
            _databaseService = database;
        }
        public DbSet<Appointment> GetAll()
        {
            return _databaseService.Appointments;

        }

        public Appointment GetById(Guid id)
        {
            return _databaseService.Appointments.FirstOrDefault(Product => Product.Id == id);
        }

        public void Add(Appointment appointment)
        {
            _databaseService.Appointments.Add(appointment);
            _databaseService.SaveChanges();
        }

        public void Update(Appointment appointment)
        {
            _databaseService.Appointments.Update(appointment);
            _databaseService.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var Appointment = GetById(id);
            _databaseService.Appointments.Remove(Appointment);
            _databaseService.SaveChanges();
        }

        public int SaveChanges()
        {
            return _databaseService.SaveChanges();
        }
    }
}
