using Microsoft.EntityFrameworkCore;
using Pitangueira.Contract.AtendimentoContract;
using Pitangueira.Model.Entities;
using Pitangueira.Repository.AtendimentoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pitangueira.Service.AtendimentoServices
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly PitangaDbContext _context;
        private readonly IClienteService _cliente;

        public AtendimentoService(PitangaDbContext context, IClienteService cliente)
        {
            _context = context;
            _cliente = cliente;
        }

        public async Task<Atendimento_> Create(Atendimento_ obj)
        {
            try
            {
                obj.UsuarioId = 1;
                obj.TipoAtendimentoId = 1;
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
                    .FirstOrDefaultAsync(a => a.Id == id);

                return atendimento;
            }
            catch (Exception e)
            {

                throw new ArgumentException(e.Message);
            }
        }

        public async Task<bool> Exists(long id)
        {
            return await Task.FromResult(_context.Atendimento.Any(e => e.Id == id));
        }

        public List<Atendimento_> GetAll()
        {

            try
            {
                List<Atendimento_> atendimentos = _context.Atendimento
                .Include(c => c.Cliente)
                .Include(c => c.Usuario)
                .OrderBy(c => c.DataExecucao)
                .ToList();

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

        public new async Task<Atendimento_> Update(long id, Atendimento_ obj)
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
    }
}
