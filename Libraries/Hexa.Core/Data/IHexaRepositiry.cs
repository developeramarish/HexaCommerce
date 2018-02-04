using Hexa.Core.Domain.Shared;
using System.Linq;

namespace Hexa.Core.Data
{
    public partial interface IHexaRepository<T> where T: BaseEntity
    {
        T GetById(int id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> Table { get; }
    }
}
