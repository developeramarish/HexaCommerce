using Hexa.Core.Domain.Shared;
using System.Collections.Generic;

namespace Hexa.Core.Domain.Customers
{
    public class CustomerRole : BaseEntity
    {
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public ICollection<CustomerCustomerRole> CustomerRoles { get; set; }
    }
}
