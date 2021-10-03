using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pitangueira.Model.Entities
{
    [Table("Atendimento")]
    public class Atendimento_ : GenericEntity
    {
        [Display(Name = "Data de Execução")]
        [DataType(DataType.Date)]
        public DateTime DataExecucao { get; set; }

        [Display(Name = "Tipo de atendimento")]
        public long? TipoAtendimentoId { get; set; }
        public TipoAtendimento TipoAtendimento { get; set; }

        [Display(Name = "Cliente")]
        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Display(Name = "Usuario")]
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

    }
}
