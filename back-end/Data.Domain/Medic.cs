using System.Collections.Generic;

namespace DataDomain
{
    public class Medic : Person
    {
        public string Category { get; set; }
        public string Specialization { get; set; }
        public double Rating { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}
