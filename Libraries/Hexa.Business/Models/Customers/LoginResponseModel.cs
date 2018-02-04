namespace Hexa.Business.Models.Customers
{
    public class LoginResponseModel
    {
        public string UserName { get; set; }

        public string Token { get; set; }

        public string CustomerTypeIds { get; set; }

        public bool IsAdmin { get; set; }
    }
}
