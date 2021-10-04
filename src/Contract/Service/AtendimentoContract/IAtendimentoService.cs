using Pitangueira.Model.Entities;
using System.Collections.Generic;

namespace Pitangueira.Contract.AtendimentoContract
{
    public interface IAtendimentoService : IGenericService<Atendimento_>
    {
        List<Cliente> DropdownListCliente();
        List<TipoAtendimento> DropdownListTipoDeAtendimento();
        List<Usuario> GetUsuario();
    }
}
