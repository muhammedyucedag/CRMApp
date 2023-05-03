using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrmApplication.UI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email alanı boş geçilemez")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email adresini hatalı girdiniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez")]
        [DisplayName("Şifre")]
        public string Password { get; set; }
    }
}
