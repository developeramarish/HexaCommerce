using System;
using Hexa.Core.Data;
using Hexa.Core.Domain.Customers;

namespace Hexa.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly HexaDbContext _context;

        IHexaRepository<Customer> _customerRepository;

        public UnitOfWork(HexaDbContext context)
        {
            _context = context;
        }

        public IHexaRepository<Customer> Customers
        {
            get
            {
                if (_customerRepository == null)
                    _customerRepository = new HexaRepository<Customer>(_context);

                return _customerRepository;
            }
        }


        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
