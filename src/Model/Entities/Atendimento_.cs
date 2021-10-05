using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pitangueira.Model.Entities
{
    [Table("Atendimento")]
    public class Atendimento_ : GenericEntity
    {
        [Required(ErrorMessage = "O campo Data de Execução é obrigatório.")]
        [Display(Name = "Data de Execução")]
        [DataType(DataType.Date)]
        public DateTime DataExecucao { get; set; }

        [Display(Name = "Tipo de atendimento")]
        public long? TipoAtendimentoId { get; set; }
        public TipoAtendimento TipoAtendimento { get; set; }

        [Required(ErrorMessage = "O campo Cliente é obrigatório.")]
        [Display(Name = "Cliente")]
        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }


        [Required(ErrorMessage = "O campo Técnico é obrigatório.")]
        [Display(Name = "Técnico")]
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

    }
}
