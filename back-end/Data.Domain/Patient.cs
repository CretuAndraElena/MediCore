using System.Collections.Generic;

namespace DataDomain
{
    public class Patient : Person
    {
        public List<Schedule> Schedules { get; set; }
    }
}
