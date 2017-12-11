using DataDomain;
using DataPersistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Repositorys
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly IDataBaseContext _databaseService;

        public ScheduleRepository(IDataBaseContext database)
        {
            _databaseService = database;
        }
        public DbSet<Schedule> GetAll()
        {
            return _databaseService.Schedules;

        }

        public Schedule GetById(Guid id)
        {
            return _databaseService.Schedules.FirstOrDefault(Product => Product.Id == id);
        }

        public void Add(Schedule Schedule)
        {
            _databaseService.Schedules.Add(Schedule);
            _databaseService.SaveChanges();
        }

        public void Update(Schedule schedule)
        {
            _databaseService.Schedules.Update(schedule);
            _databaseService.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var Schedule = GetById(id);
            _databaseService.Schedules.Remove(Schedule);
            _databaseService.SaveChanges();
        }

        public int SaveChanges()
        {
            return _databaseService.SaveChanges();
        }
    }
}
