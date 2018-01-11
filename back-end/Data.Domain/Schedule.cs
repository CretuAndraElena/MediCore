using System;

namespace DataDomain
{
    public class Schedule : BaseEntity
    {
        public DateTime Date { get; set; }
        public Medic Medic { get; set; }
        public Patient Patient { get; set; }
        public Diagnosis Diagnosis { get; set; }
    }
}