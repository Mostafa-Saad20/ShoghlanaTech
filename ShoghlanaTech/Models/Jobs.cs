using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoghlanaTech.Models
{
    public class Jobs
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "من فضلك أدخل اسم الوظيفة")]
        [Display(Name = "اسم الوظيفة")]
        public string Title { get; set; }

        [Required(ErrorMessage = "من فضلك أدخل وصـف الوظيفة")]
        [Display(Name = "وصـف الوظيفة")]
        public string Description { get; set; }

        [Required(ErrorMessage = "من فضلك أدخل نـوع الوظيفة")]
        [Display(Name = "نـوع الوظيفة")]
        public string Type { get; set; }

        [Display(Name = "الراتـب")]
        public string Salary { get; set; }

        [Required(ErrorMessage = "من فضلك أدخل سنـوات الخبـرة")]
        [Display(Name = " عـدد سنـوات الخبـرة")]
        public string YearsOfExp { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "من فضلك أدخل مجال الوظيفة")]
        [Display(Name = "مجـال الوظيفة")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int? CompanyID { get; set; }
        public Company Company { get; set; }

        [Display(Name = "تاريخ النشر")]
        public DateTime? PublishDate { get; set; }
    }
}