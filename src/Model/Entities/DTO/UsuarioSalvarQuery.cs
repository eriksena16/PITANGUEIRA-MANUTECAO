using Pitangueira.Model.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Pitangueira.Model.Entities.DTQ
{
    public class UsuarioSalvarQuery : GenericEntity
    {
        [Required(ErrorMessage = "Informe seu nome")]
        [MaxLength(100, ErrorMessage = "O nome deve ter ate 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe seu nome")]
        [MaxLength(50, ErrorMessage = "O login deve ter ate 50 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres")]
        public string Senha { get; set; }

        [Display(Name = "Tipo do usuario")]
        [Required(ErrorMessage = "Informe o tipo")]
        public TipoUsuario TipoUsuario { get; set; }

        [Required(ErrorMessage = "Confirme sua senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres")]
        [Compare(nameof(Senha), ErrorMessage = "A senha e a confirmacao nao estao iguais")]
        public string ConfirmacaoSenha { get; set; }

    }
}
