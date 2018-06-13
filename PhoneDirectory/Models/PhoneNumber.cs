using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhoneDirectory.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "Enter Phone Number:")]
        [Phone]
        public string Details { get; set; }
    }
}