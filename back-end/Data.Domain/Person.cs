

using System;

namespace DataDomain
{
    public class Person : BaseEntity
    {
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }

    }
}
