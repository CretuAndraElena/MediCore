using System;

namespace DataDomain
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Medic Medic { get; set; }
        public Patient Patient { get; set; }

        public static Schedule Create(DateTime date,Medic medic,Patient patient)
        {
            var schedule = new Schedule { Id = Guid.NewGuid() };
            schedule.Update(date,medic,patient);
            return schedule;
        }

        public void Update(DateTime date, Medic medic, Patient patient)
        {
            this.Date = date;
            this.Medic = medic;
            this.Patient = patient;
        }
    }
}