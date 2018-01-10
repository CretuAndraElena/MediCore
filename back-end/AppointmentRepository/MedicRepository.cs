using DataDomain;
using DataPersistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Repositorys
{
    public class MedicRepository : IRepository<Medic>{

        private readonly IDataBaseContext _databaseService;

        public MedicRepository(IDataBaseContext database)
        {
            _databaseService = database;
        }
        public DbSet<Medic> GetAll()
        {
            return _databaseService.Medics;

        }

        public Medic GetById(Guid id)
        {
            return _databaseService.Medics.FirstOrDefault(medic =>medic.Id == id);
        }

        public void Add(Medic medic)
        {
            _databaseService.Medics.Add(medic);
            _databaseService.SaveChanges();
        }

        public void Update(Medic medic)
        {
            _databaseService.Medics.Update(medic);
            _databaseService.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var medic = GetById(id);
            _databaseService.Medics.Remove(medic);
            _databaseService.SaveChanges();
        }

        public int SaveChanges()
        {
            return _databaseService.SaveChanges();
        }

    }
}
