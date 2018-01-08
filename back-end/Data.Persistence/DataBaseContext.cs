using Microsoft.EntityFrameworkCore;

namespace DataPersistence
{
    public class DataBaseContext: DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<DataDomain.Medic> Medics { get; set; }
        public DbSet<DataDomain.Patient> Patients { get; set; }
        public DbSet<DataDomain.Schedule> Schedules { get; set; }
    }
}
