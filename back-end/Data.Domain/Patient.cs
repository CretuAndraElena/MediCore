using System;
using System.Collections.Generic;

namespace DataDomain
{
    public class Patient:Person
    {
        public List<Diagnosis> Diagnosis { get; set; }
        public List<Schedule> Schedules { get; set; }

        public Patient(string cnp,string firstName, string lastName, string userName, string password, string gender,
            DateTime birthday, string emailAddres) : base(cnp,lastName, firstName, userName, password, gender, birthday,"patient",emailAddres) => throw new NotImplementedException();

        public Patient() : base()
        {
        }

        public static Patient Create(List<Diagnosis> diagnosis,List<Schedule> schedules)
        {
            var patient = new Patient();
            patient.Update(diagnosis,schedules);
            return patient;
        }

        public void Update(List<Diagnosis> diagnosis, List<Schedule> schedules)
        {
            this.Schedules = schedules;
            this.Diagnosis = diagnosis;
        }
    }
}
