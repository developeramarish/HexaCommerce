using Hexa.Core.Domain.Customers;
using Hexa.Core.Domain.Shared;

namespace Hexa.Core.Domain.Logs
{
    public class Log : BaseEntity
    {
        public string ShortMessage { get; set; }

        public string FullMessage { get; set; }

        public string IpAddress { get; set; }

        public int? CustomerId { get; set; }

        public string PageUrl { get; set; }

        public string PageReferrer { get; set; }

        public Customer Customer { get; set; }
    }
}
