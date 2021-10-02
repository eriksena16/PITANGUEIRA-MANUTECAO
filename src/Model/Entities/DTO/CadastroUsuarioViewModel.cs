using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pitangueira.Model.Entities.DTO
{
    public class UsuarioDTO
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

            [Required(ErrorMessage = "Confirme sua senha")]
            [DataType(DataType.Password)]
            [Display(Name = "Confirmar senha")]
            [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres")]
            [Compare(nameof(Senha), ErrorMessage = "A senha e a confirmacao nao estao iguais")]
            public string ConfirmacaoSenha { get; set; }
        
    }
}
