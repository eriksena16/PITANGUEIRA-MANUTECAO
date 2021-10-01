using Pitangueira.Contract.AtendimentoContract;
using Pitangueira.Model.Entities;
using Pitangueira.Repository.AtendimentoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitangueira.Service.AtendimentoServices
{
    public class ClienteService : IClienteService
    {
        private readonly ApplicationDbContext _context;

        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Cliente> Create(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> Delete(long? id)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> DeleteConfirmed(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> Details(long? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(long id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> GetAll()
        {
            return _context.Cliente.OrderBy(c=> c.Name).ToList();
        }

        public Task<Cliente> GetUpdate(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> Update(long id, Cliente obj)
        {
            throw new NotImplementedException();
        }
    }
}
