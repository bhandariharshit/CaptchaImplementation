using System.ComponentModel.DataAnnotations;

namespace CaptchaImplementation.Models
{
    public class CaptchaModel
    {
        [Required(ErrorMessage ="Please enter captcha text")]
        [StringLength(6)]
        public string Text { get; set; }
    }
    public static class Cons
    {
        public const string CaptchaSessionKey= "CaptchaSessionKey";
    }
}