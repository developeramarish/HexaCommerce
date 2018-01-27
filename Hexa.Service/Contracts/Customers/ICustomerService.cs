using Hexa.Business.Models.Customers;
using Hexa.Core.Domain.Customers;
using System.Collections.Generic;

namespace Hexa.Service.Contracts.Customers
{
    public interface ICustomerService
    {
        void DeleteCustomer(Customer customer);

        Customer GetCustomerById(int customerId);

        void InsertCustomer(Customer customer);

        void UpdateCustomer(Customer customer);

        IList<Customer> GetAllCustomers(string name);

        CustomerModel ValidateCustomer(string username, string password);

        CustomerModel ValidateCustomerRole(int customerId, int customerRoleId);

        TokenManager GetTokenByCustomerId(int customerId);

        TokenManager GetTokenById(int id);

        void DeleteToken(TokenManager token);

        void InsertToken(TokenManager token);

        LoginResponseModel GetLoginResponse(CustomerModel customer);

        LoginResponseModel GenerateToken(CustomerLoginTokenModel tokenModel);
    }
}
