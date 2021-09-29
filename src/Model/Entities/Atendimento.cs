using Pitangueira.Model.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pitangueira.Model.Entities
{
    public class Atendimento: GenericEntity
    {
        [Display(Name ="Data de Execução")]
        public DateTime DataExecucao { get; set; }
        [Display(Name = "Tipo de atendimento")]
        public AtendimentoType Type { get; set; }
        [Display(Name = "Cliente")]
        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public long UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
