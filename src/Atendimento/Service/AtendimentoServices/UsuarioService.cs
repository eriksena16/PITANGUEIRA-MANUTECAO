using Microsoft.EntityFrameworkCore;
using Pitangueira.Contract.AtendimentoContract;
using Pitangueira.Model.Entities;
using Pitangueira.Model.Entities.DTQ;
using Pitangueira.Model.Entities.Utils;
using Pitangueira.Repository.AtendimentoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
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
            
          return _context.Usuario.Any(u => u.UserName == obj.Username);
            
        }


        public List<Usuario> GetAll()
        {
            try
            {
                List<Usuario> usuarios = _context.Usuario.ToList();

                return usuarios;
            }
            catch (Exception e)
            {

                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Usuario> Login(Login obj)
        {
            return  await _context.Usuario.FirstOrDefaultAsync(c => c.UserName == obj.Username);
        }
    }
}
