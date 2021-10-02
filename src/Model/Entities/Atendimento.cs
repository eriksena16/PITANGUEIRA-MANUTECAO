using Pitangueira.Model.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pitangueira.Model.Entities
{
    public class Atendimento: GenericEntity
    {
        [Display(Name ="Data de Execução")]
        [DataType(DataType.Date)]
        public DateTime DataExecucao { get; set; }

        [Display(Name = "Tipo de atendimento")]
        public long? TipoAtendimentoId { get; set; }
        public TipoAtendimento TipoAtendimento { get; set; }

        [Display(Name = "Cliente")]
        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Display(Name = "Usuario")]
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

    }
}
