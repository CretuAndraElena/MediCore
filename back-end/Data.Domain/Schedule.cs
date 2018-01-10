using System;
using System.ComponentModel.DataAnnotations;

namespace DataDomain
{
    public class Schedule
    {
        [Required]
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        public Medic Medic { get; set; }
        public Patient Patient { get; set; }
       /* public string Specialization { get; set; }
        public string Simptome { get; set; }*/
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