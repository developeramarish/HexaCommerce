using Hexa.Core.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hexa.Core.Domain.Customers
{
    public class CustomerCustomerRole : BaseEntity
    {
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int CustomerRoleId { get; set; }

        public CustomerRole CustomerRole { get; set; }
    }
}
