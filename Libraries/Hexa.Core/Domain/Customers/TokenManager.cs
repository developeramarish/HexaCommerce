using Hexa.Core.Domain.Customers;
using Hexa.Core.Domain.Shared;
using System;

namespace Hexa.Core.Domain.Customers
{
    public class TokenManager : BaseEntity
    {
        public string TokenKey { get; set; }

        public DateTime IssuedOn { get; set; }

        public DateTime ExpiresOn { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
