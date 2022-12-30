using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ShoghlanaTech.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = " Invalid Email Address! ")]
        [Display(Name = "Admin Email ")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Admin Password")]
        public string Password { get; set; }
    }
}