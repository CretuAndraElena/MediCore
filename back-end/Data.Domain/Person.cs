using System;

namespace DataDomain
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Cnp { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Role { get; set; }

    }
}
