using DataDomain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Repositorys
{
    public interface IMedicRepository
    {
        DbSet<Medic> GetAll();
        Medic GetById(Guid id);
        void Add(Medic medic);
        void Update(Medic medic);
        void Delete(Guid id);
        int SaveChanges();
    }
}