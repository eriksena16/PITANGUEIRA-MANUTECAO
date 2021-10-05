using Pitangueira.Model.Entities;
using System.Collections.Generic;

namespace Pitangueira.Contract.AtendimentoContract
{
    public interface IClienteService
    {
        List<Cliente> GetAll();
    }
}
