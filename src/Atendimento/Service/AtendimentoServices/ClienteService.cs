using Pitangueira.Contract.AtendimentoContract;
using Pitangueira.Model.Entities;
using Pitangueira.Repository.AtendimentoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pitangueira.Service.AtendimentoServices
{
    public class ClienteService : IClienteService
    {
        private readonly PitangaDbContext _context;

        public ClienteService(PitangaDbContext context)
        {
            _context = context;
        }

        public List<Cliente> GetAll()
        {
            return _context.Cliente.OrderBy(c => c.Name).ToList();
        }

    }
}
