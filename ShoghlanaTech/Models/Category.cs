using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoghlanaTech.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "مجال الوظيـفـة")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name="الوصـف")]
        public string Description { get; set; }

        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Required")]
        public string Image { get; set; }

        public ICollection<Jobs> Jobs { get; set; }


    }
}