using Hexa.Core.Domain.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace Hexa.Core.Data
{
    public partial interface IHexaRepository<T> where T: BaseEntity
    {
        Task<T> GetById(int id);

        Task Insert(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        IQueryable<T> Table { get; }
    }
}
