using System;
using System.Collections.Generic;

namespace DataDomain
{
    public class Medic : Person
    {
        public string Specialization { get; set; }
        public double Rating { get; set; }
        public List<Patient> Patients { get; set; }
        public List<Schedule> Schedules { get; set; }

        public Medic(string cnp, string firstName, string lastName, string userName, string password, string gender,
            DateTime birthday,string specialization, string emailAddres) : base(cnp, lastName, firstName, userName, password, gender, birthday,"medic",emailAddres)
        {
            Specialization = specialization;
            Rating = 0.0;
        }

        public Medic() : base()
        {
        }

        public static Patient Create(List<Diagnosis> diagnosis, List<Schedule> schedules)
        {
            var patient = new Patient();
            patient.Update(diagnosis, schedules);
            return patient;
        }

        public void Update(List<Patient> patients, List<Schedule> schedules)
        {
            this.Schedules = schedules;
            this.Patients = patients;
        }
    }
}
