using Hexa.Core.Data;
using Hexa.Core.Domain.Customers;

namespace Hexa.Data
{
    public interface IUnitOfWork
    {
        IHexaRepository<Customer> Customers { get; }

        int SaveChanges();
    }
}
