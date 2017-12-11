using DataDomain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Repositorys
{
    public interface IScheduleRepository
    {
        DbSet<Schedule> GetAll();
        Schedule GetById(Guid id);
        void Add(Schedule product);
        void Update(Schedule product);
        void Delete(Guid id);
        int SaveChanges();
    }
}
