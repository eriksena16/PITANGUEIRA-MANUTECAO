using Pitangueira.Model.Entities;
using Pitangueira.Model.Entities.DTQ;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pitangueira.Contract.AtendimentoContract
{
    public interface IUsuarioService 
    {
        List<Usuario> GetAll();
        Task<Usuario> Create(UsuarioSalvarQuery obj);
        bool HasUsuario(UsuarioSalvarQuery obj);
        Task<Usuario> Login(Login obj);
    }
}
