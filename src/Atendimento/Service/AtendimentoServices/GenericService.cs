using Microsoft.EntityFrameworkCore;
using Pitangueira.Contract.AtendimentoContract;
using Pitangueira.Model.Entities;
using Pitangueira.Repository.AtendimentoRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitangueira.Service.AtendimentoServices
{
    public class GenericService<T> : IGenericService<T> where T : GenericEntity, new()
    {
        private readonly DbSet<T> entities;
        public GenericService(PitangaDbContext context)
        {
            entities = context.Set<T>();
        }

       virtual public Task<T> Create(T obj)
        {
            throw new NotImplementedException();
        }

        public Task<T> Delete(long? id)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteConfirmed(long id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Details(long? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(long id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetUpdate(long id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(long id, T obj)
        {
            throw new NotImplementedException();
        }
    }
}
