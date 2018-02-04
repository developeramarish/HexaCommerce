using Hexa.Business.Models.Shared;

namespace Hexa.Business.Models.Customers
{
    public class CustomerModel : BaseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public bool Active { get; set; }
    }
}
