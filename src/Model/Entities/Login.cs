using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Pitangueira.Model.Entities
{
    public class Login
    {
        [HiddenInput]
        public string UrlRetorno { get; set; }

        [Required(ErrorMessage = "Informe o login")]
        [MaxLength(50, ErrorMessage = "O login deve ter ate 50 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres")]
        public string Senha { get; set; }
    }
}
