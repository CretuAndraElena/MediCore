using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Models
{
    public class RegisterViewModel
    {
        private readonly String[] _gender= {"Female","Man"};
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is Required")]
        [RegularExpression(@"^[a-zA-Z0-9]+$",
            ErrorMessage = "user name must be combination of letters and numbers only.")]
        [Remote("UsernameExists", "Account",
            HttpMethod = "POST", ErrorMessage = "User name already registered.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "CNP is Required")]
        public string Cnp { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Both Password fields must match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Remote("EmailExists", "Account",
            HttpMethod = "POST", ErrorMessage = "Email address already registered.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Birthday")]
        public DateTime Birthday { get; set; }
        public IEnumerable<SelectListItem> GenderItems
        {
            get { return new SelectList(_gender); }
        }
    }
}
