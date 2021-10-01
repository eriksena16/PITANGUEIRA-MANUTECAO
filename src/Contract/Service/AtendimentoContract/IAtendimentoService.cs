using Pitangueira.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pitangueira.Contract.AtendimentoContract
{
    public interface IAtendimentoService : IGenericService<Atendimento>
    {
        List<Cliente> DropdownListCliente();
    }
}
