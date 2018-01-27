using Hexa.Core.Domain.Shared;
using System;
using System.Collections.Generic;

namespace Hexa.Core.Domain.Customers
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            this.CustomerGuid = Guid.NewGuid();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
     
        public Guid CustomerGuid { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public string AdminComment { get; set; }

        public int FailedLoginAttempts { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public int DisplayOrder { get; set; }

        public ICollection<CustomerCustomerRole> CustomerRoles { get; set; }
    }
}
