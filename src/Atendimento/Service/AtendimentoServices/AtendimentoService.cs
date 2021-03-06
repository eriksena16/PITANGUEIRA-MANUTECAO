using Microsoft.EntityFrameworkCore;
using Pitangueira.Contract.AtendimentoContract;
using Pitangueira.Model.Entities;
using Pitangueira.Repository.AtendimentoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pitangueira.Model.Entities.Enums;

namespace Pitangueira.Service.AtendimentoServices
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly PitangaDbContext _context;
        private readonly IClienteService _cliente;
        private readonly IUsuarioService _usuario;

        public AtendimentoService(PitangaDbContext context, IClienteService cliente, IUsuarioService usuario)
        {
            _context = context;
            _cliente = cliente;
            _usuario = usuario;
        }

        public async Task<Atendimento_> Create(Atendimento_ obj)
        {
            try
            {

                if (obj.TipoAtendimento.Name == null)
                {
                    obj.TipoAtendimento = null;
                }

                _context.Add(obj);

                await _context.SaveChangesAsync();

                return obj;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Atendimento_> Delete(long? id)
        {
            try
            {
                return await Details(id);
            }
            catch (Exception e)
            {

                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Atendimento_> DeleteConfirmed(long id)
        {
            try
            {
                Atendimento_ atendimento = await _context.Atendimento.FindAsync(id);

                _context.Atendimento.Remove(atendimento);

                await _context.SaveChangesAsync();

                return atendimento;
            }
            catch (Exception e)
            {

                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Atendimento_> Details(long? id)
        {
            try
            {
                Atendimento_ atendimento = await _context.Atendimento
                    .Include(c => c.Usuario)
                    .Include(c => c.Cliente)
                    .Include(c=> c.TipoAtendimento)
                    .FirstOrDefaultAsync(a => a.Id == id);

                return atendimento;
            }
            catch (Exception e)
            {

                throw new ArgumentException(e.Message);
            }
        }

        public bool Exists(long id)
        {
            return _context.Atendimento.Any(e => e.Id == id);
        }

        public List<Atendimento_> GetAll()
        {

            try
            {
                
                List<Atendimento_> atendimentos = _context.Atendimento
                .Include(c => c.Cliente)
                .Include(c => c.Usuario)
                .Include(c => c.TipoAtendimento)
                .OrderBy(c => c.DataExecucao)
                .ToList();

                foreach (var obj in atendimentos)
                {
                    
                }

                return atendimentos;
            }
            catch (Exception e)
            {

                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Atendimento_> GetUpdate(long id)
        {


            try
            {
                Atendimento_ atendimento = await _context.Atendimento.FindAsync(id);

                return atendimento;
            }
            catch (Exception e)
            {

                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Atendimento_> Update(long id, Atendimento_ obj)
        {


            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();

                return obj;
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new ArgumentException(e.Message);
            }
        }

        public List<Cliente> DropdownListCliente()
        {
            var clienteQuery = _cliente.GetAll();

            return clienteQuery;
        }
        public List<TipoAtendimento> DropdownListTipoDeAtendimento()
        {
            var tipoatendiemntoQuery = _context.TipoAtendimento.ToList();

            return tipoatendiemntoQuery;
        }
        public List<Usuario> GetUsuario()
        {
            var usuarios = _usuario.GetAll().Where(c=> c.TipoUsuario == TipoUsuario.Tecnico).ToList();

            return usuarios;
        }
    }
}
