using System;

namespace DataDomain
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Doctor { get; set; }
        public string Patient { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }

        public static Appointment Create(string description,string doctor,string patient,string type,DateTime startDate)
        {
            var appointment = new Appointment { Id = Guid.NewGuid() };
           appointment.Update(description,doctor,patient,type,startDate);
            return appointment;
        }

        public void Update(string description, string doctor, string patient, string type, DateTime startDate)
        {
            this.Description = description;
            this.Doctor = doctor;
            this.Patient = patient;
            this.Type = type;
            this.StartDate = startDate;
        }
    }
}
