using System;
using System.ComponentModel.DataAnnotations;
using Helpers;

namespace DataDomain
{
    public class Person
    {

        public Person()
        {
        }

        public Person(string cnp, string firstName, string lastName, string username, string password, string gender, DateTime birthday, string role,string emailAddres)
        {
            Id=new Guid();
            Cnp = cnp;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = SHA1.Encode(password);
            Gender = gender;
            Birthday = birthday;
            Role = role;
            EmailAddres = emailAddres;
        }

        [Required]
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "CNP")]
        [MaxLength(14)]
        [MinLength(14)]
        public string Cnp { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email Addres")]
        public string EmailAddres { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Birthday")]
        public DateTime Birthday{ get; set; }
        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }

    }
}
