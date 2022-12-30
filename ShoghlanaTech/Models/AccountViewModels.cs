using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoghlanaTech.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "مـن فضــلـك أدخــل بـريـدك الألكتـرونـي")]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage = "مـن فضــلـك أدخــل بـريـدك الألكتـرونـي")]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "مـن فضــلـك أدخــل بـريـدك الألكتـرونـي")]
        [Display(Name = "البريد الإلكتروني")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "مـن فضــلـك أدخــل كلــمة الـسـر")]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة الـســر")]
        public string Password { get; set; }

        [Display(Name = "تذكــرني ؟")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "مـن فضــلـك أدخــل اسـم المستـخدم")]
        [Display(Name = "اسـم المستـخدم")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "مـن فضــلـك أختـر نـوع الحسـاب")]
        [Display(Name = "نـوع الحسـاب")]
        public string UserType { get; set; }

        [Required(ErrorMessage = "مـن فضــلـك أدخــل بـريـدك الألكتـرونـي")]
        [EmailAddress]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }

        [Required(ErrorMessage = "مـن فضــلـك أدخــل كـلـمة السـر")]
        [StringLength(100, ErrorMessage = "كـلـمة الـســر لابـد أن تـحـتوي على 6 أحـرف علـى الأقــل ", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة الـســر")]
        public string Password { get; set; }

        [Required(ErrorMessage = "مـن فضــلـك أدخــل كـلـمة الـسـر مـرة أخــرى")]
        [DataType(DataType.Password)]
        [Display(Name = "تـأكيد كلمة الـســر")]
        [Compare("Password", ErrorMessage = "كلـمـة الـســر غـيـر متـطـابـقـة")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "مـن فضــلـك أدخــل بـريـدك الألكتـرونـي")]
        [EmailAddress]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }

        [Required(ErrorMessage = "مـن فضــلـك أدخــل كـلـمة السـر")]
        [StringLength(100, ErrorMessage = "كـلـمة الـســر لابـد أن تـحـتوي على 6 أحـرف علـى الأقــل", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة الـســر")]
        public string Password { get; set; }

        [Required(ErrorMessage = "مـن فضــلـك أدخــل كـلـمة الـسـر مـرة أخــرى")]
        [DataType(DataType.Password)]
        [Display(Name = "تـأكـيـد كلمة الـســر")]
        [Compare("Password", ErrorMessage = "كلـمـة الـســر غـيـر متـطـابـقـة")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "مـن فضــلـك أدخــل بـريـدك الألكتـرونـي")]
        [EmailAddress]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }
    }

}
