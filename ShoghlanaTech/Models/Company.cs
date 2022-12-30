using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoghlanaTech.Models
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }

        [Required(ErrorMessage = "مطلوب")]
        [EmailAddress(ErrorMessage = " البريد الإلكتروني غير صالح ")]
        [Display(Name = "البريد الإلكتروني ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "مطلوب")]
        [StringLength(100, ErrorMessage = "كـلـمة المرور لابـد أن تـحـتوي على 6 أحـرف علـى الأقــل ", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "أنشئ كلمة مرور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "مطلوب")]
        [Display(Name = "اسم الشركة ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "مطلوب")]
        [Display(Name = "وصـف الشركة")]
        public string Description { get; set; }

        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "مطلوب")]
        [Display(Name = "صورة شعار للشركة")]
        public string Image { get; set; }

        [Required(ErrorMessage = "مطلوب")]
        [Display(Name = "عنـوان الشركة")]
        public string Address { get; set; }

        [Display(Name = "الموقع الألكتروني ")]
        public string Website { get; set; }

        [Display(Name = "عدد العاملين بالشركة")]
        public string EmpCount { get; set; }

        public ICollection<Jobs> Jobs { get; set; }
    }

}