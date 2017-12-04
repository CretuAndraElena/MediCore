using Microsoft.EntityFrameworkCore;
using System;

namespace DataPersistence
{
    public class DataBaseContext: DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<DataDomain.Appointment> Appointments { get ; set; }
    }
}
