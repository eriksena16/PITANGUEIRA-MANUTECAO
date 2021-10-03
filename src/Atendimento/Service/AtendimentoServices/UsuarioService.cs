using Pitangueira.Contract.AtendimentoContract;
using Pitangueira.Model.Entities;
using Pitangueira.Model.Entities.DTQ;
using Pitangueira.Model.Entities.Utils;
using Pitangueira.Repository.AtendimentoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitangueira.Service.AtendimentoServices
{
    public class UsuarioService :  IUsuarioService
    {
        private readonly PitangaDbContext _context;

        public UsuarioService(PitangaDbContext context)
        {
            _context = context;
        }


        public async Task<Usuario> Create(UsuarioSalvarQuery obj)
        {
            try
            {
                HasUsuario(obj);

                Usuario usuario = new Usuario
                {
                    Nome = obj.Nome,
                    UserName = obj.Username,
                    Senha = Hash.GerarHash(obj.Senha),
                    TipoUsuario = obj.TipoUsuario

                };
                

                _context.Usuario.Add(usuario);

               await _context.SaveChangesAsync();

                return usuario;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool HasUsuario( UsuarioSalvarQuery obj)
        {
            
          return _context.Usuario.Count(u => u.UserName == obj.Username) > 0;
            
        }

        public  Task<Usuario> Delete(long? id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> DeleteConfirmed(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Details(long? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(long id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetUpdate(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Update(long id, Usuario obj)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> Login(Login obj)
        {
            return  _context.Usuario.FirstOrDefault(c => c.UserName == obj.Username);
        }
    }
}
