using DataDomain;
using Microsoft.EntityFrameworkCore;

namespace DataPersistence
{
    public interface IDataBaseContext
    {
        DbSet<Appointment> Appointments { get; set; }
        int SaveChanges();
}
}
