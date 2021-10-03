using System.Collections.Generic;

namespace Pitangueira.Model.Entities
{
    public class Cliente : Pessoa
    {

        ICollection<Atendimento_> Atendimentos { get; set; }
    }
}