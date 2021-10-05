using Pitangueira.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Pitangueira.Contract.AtendimentoContract
{
    public interface IGenericService<T>
    {
        List<T> GetAll();
        Task<T> Details(long? id);
        Task<T> Create(T obj);
        Task<T> GetUpdate(long id);
        Task<T> Update(long id, T obj);
        Task<T> Delete(long? id);
        Task<T> DeleteConfirmed(long id);
        bool Exists(long id);

        //Task<TReturn> Create<TReturn>(T obj);
    }
}
