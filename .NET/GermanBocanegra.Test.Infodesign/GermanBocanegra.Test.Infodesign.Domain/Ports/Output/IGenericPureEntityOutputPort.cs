using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs;
using GermanBocanegra.Test.Infodesign.Domain.Models.Entities;

namespace GermanBocanegra.Test.Infodesign.Domain.Ports.Output
{
    public interface IGenericPureEntityOutputPort<T, K> where T : BaseDTO where K : BaseEntity
    {
        Task<T> List(Func<K, bool> predicate);
        Task<T> Get(long id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity, bool logicDelete = true);
    }
}
