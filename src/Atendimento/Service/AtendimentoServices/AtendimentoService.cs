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
        private readonly ApplicationDbContext _context;
        private readonly IClienteService _cliente;

        public AtendimentoService(ApplicationDbContext context, IClienteService cliente)
        {
            _context = context;
            _cliente = cliente;
        }

        public async Task<Atendimento> Create(Atendimento obj)
        {
            try
            {
                _context.Add(obj);

                await _context.SaveChangesAsync();

                return obj;
            }
            catch (Exception e)
            {

                throw new ArgumentException("Ops! algo de errado aconteceu " + e.Message);
            }
        }

        public async Task<Atendimento> Delete(long? id)
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

        public async Task<Atendimento> DeleteConfirmed(long id)
        {
            try
            {
                Atendimento atendimento = await _context.Atendimento.FindAsync(id);

                _context.Atendimento.Remove(atendimento);

                await _context.SaveChangesAsync();

                return atendimento;
            }
            catch (Exception e)
            {

                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Atendimento> Details(long? id)
        {
            try
            {
                Atendimento atendimento = await _context.Atendimento
                    .Include(c => c.User)
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

        public List<Atendimento> GetAll()
        {

            try
            {
                List<Atendimento> atendimentos = _context.Atendimento
                .Include(c => c.Cliente)
                .Include(c => c.User)
                .OrderBy(c => c.DataExecucao)
                .ToList();

                return atendimentos;
            }
            catch (Exception e)
            {

                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Atendimento> GetUpdate(long id)
        {


            try
            {
                Atendimento atendimento = await _context.Atendimento.FindAsync(id);

                return atendimento;
            }
            catch (Exception e)
            {

                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Atendimento> Update(long id, Atendimento obj)
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
