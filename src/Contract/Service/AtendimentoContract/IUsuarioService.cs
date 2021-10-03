using Pitangueira.Model.Entities;
using Pitangueira.Model.Entities.DTQ;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pitangueira.Contract.AtendimentoContract
{
    public interface IUsuarioService 
    {
        List<Usuario> GetAll();
        Task<Usuario> Details(long? id);
        Task<Usuario> Create(UsuarioSalvarQuery obj);
        Task<Usuario> GetUpdate(long id);
        Task<Usuario> Update(long id, Usuario obj);
        Task<Usuario> Delete(long? id);
        Task<Usuario> DeleteConfirmed(long id);
        bool HasUsuario(UsuarioSalvarQuery obj);
        Task<Usuario> Login(Login obj);
    }
}
