using System;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class SchedulesViewModel
    {
        [Required(ErrorMessage = "First Name is required")]
        public string Simptome { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string Specializare { get; set; }

        [Required(ErrorMessage = "Username is Required")]
        public string Medic { get; set; }

        [Required(ErrorMessage = "Birthday")]
        public DateTime Date { get; set; }
    }
}