using Microsoft.EntityFrameworkCore;

namespace DataPersistence
{
    public sealed class DataBaseContext: DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<DataDomain.Medic> Medics { get; set; }
        public DbSet<DataDomain.Patient> Patients { get; set; }
        public DbSet<DataDomain.Schedule> Schedules { get; set; }
        public DbSet<DataDomain.Diagnosis> Diagnoses { get; set; }
        public DbSet<DataDomain.Person> Persons { get; set; }
    }
}
