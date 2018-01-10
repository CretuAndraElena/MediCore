

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Presentation.Models
{
    public class EmailSenderViewModel
    {
        [Required(ErrorMessage = "Username for person is Required")]
        public string ToUsername { get; set; } 

        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
