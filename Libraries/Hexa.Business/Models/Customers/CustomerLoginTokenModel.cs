using System.Collections.Generic;

namespace Hexa.Business.Models.Customers
{
    public class CustomerLoginTokenModel
    {
        public CustomerLoginTokenModel()
        {
            CustomerRoleIds = new List<int>();
            CustomerRoleNames = new List<string>();
        }

        public int CustomerId { get; set; }
        public string UserName { get; set; }
        public List<int> CustomerRoleIds { get; set; }
        public List<string> CustomerRoleNames { get; set; }
    }
}
