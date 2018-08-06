using Hexa.Business.Models.Customers;
using Hexa.Core.Domain.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hexa.Service.Contracts.Customers
{
    public interface ICustomerService
    {
        Task DeleteCustomer(Customer customer);

        Task<Customer> GetCustomerById(int customerId);

        Task InsertCustomer(Customer customer);

        Task UpdateCustomer(Customer customer);

        Task<IList<Customer>> GetAllCustomers(string name);

        Task<CustomerModel> ValidateCustomer(string username, string password);

        Task<CustomerModel> ValidateCustomerRole(int customerId, int customerRoleId);

        Task<TokenManager> GetTokenByCustomerId(int customerId);

        Task<TokenManager> GetTokenById(int id);

        Task DeleteToken(TokenManager token);

        Task InsertToken(TokenManager token);

        Task<LoginResponseModel> GetLoginResponse(CustomerModel customer);

        Task<LoginResponseModel> GenerateToken(CustomerLoginTokenModel tokenModel);
    }
}
