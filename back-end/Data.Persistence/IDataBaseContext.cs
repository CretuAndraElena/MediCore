using DataDomain;
using Microsoft.EntityFrameworkCore;

namespace DataPersistence
{
    public interface IDataBaseContext
    {
        DbSet<Schedule> Schedules { get; set; }
        DbSet<Medic> Medics { get; set; }
        DbSet<Patient> Patients { get; set; }
        int SaveChanges();
}
}
