using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.WebUI.Model
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email é necessário")]
        [EmailAddress(ErrorMessage = "Formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Uma senha é necessária")]
        [StringLength(20, ErrorMessage = "A senha precisa ter no máximo 20 caracteres e no minimo 6", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
