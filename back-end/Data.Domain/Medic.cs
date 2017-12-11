using System;
using System.Collections.Generic;
using System.Text;

namespace DataDomain
{
    public class Medic : Person
    {
        public string Category { get; set; }
        public string Specialization { get; set; }
        public double Rating { get; set; }
        public List<Schedule> Schedules { get; set; }
        public List<Patient> Patients { get; set; }

        public static Medic Create( string category,string specialization,double rating ,List<Schedule> schedules,List<Patient> patients)
        {
            var medic = new Medic { Id = Guid.NewGuid() };
            medic.Update(category,specialization,rating,schedules,patients);
            return medic;
        }

        public void Update(string category, string specialization, double rating, List<Schedule> schedules, List<Patient> patients)
        {
            this.Category = category;
            this.Rating = rating;
            this.Schedules = new List<Schedule>(schedules);
            this.Patients = new List<Patient>(patients);
            this.Specialization =specialization;
        }
    }
}
