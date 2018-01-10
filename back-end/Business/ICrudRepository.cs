using System;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public interface ICrudRepository<T> where T : class
    {
        DbSet<T> GetAll();
        T GetById(Guid id);
        void Add(T t);
        void Update(T t);
        void Delete(Guid id);
        int SaveChanges();
    }
}