using System;
using System.Collections.Generic;
using System.IO;

namespace DataDomain
{
    public class Patient:Person
    {
        public List<Diagnosis> Diagnosis { get; set; }
        public List<Schedule> Schedules { get; set; }
        public static Patient Create(List<Diagnosis> diagnosis,List<Schedule> schedules)
        {
            var patient = new Patient { Id = Guid.NewGuid() };
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
