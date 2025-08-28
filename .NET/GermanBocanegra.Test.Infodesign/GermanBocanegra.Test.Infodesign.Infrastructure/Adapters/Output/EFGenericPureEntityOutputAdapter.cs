using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs;
using GermanBocanegra.Test.Infodesign.Domain.Models.Entities;
using GermanBocanegra.Test.Infodesign.Domain.Ports.Output;
using GermanBocanegra.Test.Infodesign.Infrastructure.Adapters.Output.ORMDefinitions.EntityFramework;

namespace GermanBocanegra.Test.Infodesign.Infrastructure.Adapters.Output
{
    public class EFGenericPureEntityOutputAdapter<T, K> : IGenericPureEntityOutputPort<T, K> where T : BaseDTO where K : BaseEntity
    {
        private readonly MainEntityFrameworkContext context;

        public EFGenericPureEntityOutputAdapter(MainEntityFrameworkContext context)
        {
            this.context = context;
        }

        public Task<T> List(Func<K, bool> predicate)
        {
            context.Set<K>().Where(predicate);

            throw new NotImplementedException();
        }

        public Task<T> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Delete(T entity, bool logicDelete = true)
        {
            throw new NotImplementedException();
        }
    }
}
