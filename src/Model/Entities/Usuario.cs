using Pitangueira.Model.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Pitangueira.Model.Entities
{
    public class Usuario : GenericEntity
    {
        [Display(Name = "Nome de usuario")]
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Display(Name = "Nome")]
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Display(Name = "Senha")]
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Tipo de Usuario")]
        [Required]
        public TipoUsuario TipoUsuario { get; set; }



    }
}
