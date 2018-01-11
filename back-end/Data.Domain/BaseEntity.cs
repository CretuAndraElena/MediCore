using System;
using System.ComponentModel.DataAnnotations;

namespace DataDomain
{
    public class BaseEntity
    {
        [Required]
        [Display(Name = "Id")]
        public Guid Id { get; set; }
    }
}