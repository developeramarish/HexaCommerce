using Hexa.Service.Contracts.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using Hexa.Core.Domain.Customers;
using Hexa.Core.Data;
using Hexa.Business.Models.Customers;
using AutoMapper;
using Hexa.Core;
using Hexa.Business;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Hexa.Service.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        #region Fields

        private readonly IHexaRepository<Customer> _customerRepository;
        private readonly IHexaRepository<TokenManager> _tokenManagerRepository;
        private readonly IHexaRepository<CustomerRole> _customerRoleRepository;
        private readonly IHexaRepository<CustomerCustomerRole> _customerCustomerRoleRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public CustomerService(IHexaRepository<Customer> customerRepository,
            IHexaRepository<TokenManager> tokenManagerRepository,
            IHexaRepository<CustomerRole> customerRoleRepository,
            IHexaRepository<CustomerCustomerRole> customerCustomerRoleRepository,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _tokenManagerRepository = tokenManagerRepository;
            _customerRoleRepository = customerRoleRepository;
            _customerCustomerRoleRepository = customerCustomerRoleRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task DeleteCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("Customer");

            customer.Deleted = true;
            await UpdateCustomer(customer);
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            if (customerId == 0)
                return null;

            return await _customerRepository.GetById(customerId);
        }

        public async Task InsertCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("Customer");

            await _customerRepository.Insert(customer);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("Customer");

            await _customerRepository.Update(customer);
        }

        public async Task<IList<Customer>> GetAllCustomers(string name)
        {
            var query = _customerRepository.Table;
            query = query.Where(c => c.Active);
            query = query.Where(c => !c.Deleted);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.FirstName.Contains(name));

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.LastName.Contains(name));

            return await query.OrderBy(a => a.DisplayOrder).ToListAsync();
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            var query = from c in _customerRepository.Table
                        orderby c.Id
                        where c.Email == email
                        select c;
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Customer> GetCustomerByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            var query = from c in _customerRepository.Table
                        orderby c.Id
                        where c.UserName == username
                        select c;
            return await query.FirstOrDefaultAsync();
        }

        public async Task<CustomerModel> ValidateCustomer(string username, string password)
        {
            var customer = await GetCustomerByUsername(username);

            if (customer == null)
                return null;

            if (customer.Deleted)
                return null;

            if (!customer.Active)
                return null;

            if (!customer.Password.Equals(EncryptionLibrary.EncryptText(password)))
            {
                customer.FailedLoginAttempts++;
                if (customer.FailedLoginAttempts > 0 && customer.FailedLoginAttempts >= 5)
                {
                    //todo: lock account for 24 hours 
                }
                await UpdateCustomer(customer);
                return null;
            }

            return _mapper.Map<CustomerModel>(customer);
        }

        public async Task<CustomerModel> ValidateCustomerRole(int customerId, int customerRoleId)
        {
            var customer = await _customerRepository.Table.Include(a => a.CustomerRoles).FirstOrDefaultAsync(a=>a.Id == customerId);

            if (customer == null)
                return null;

            if (customer.Deleted)
                return null;

            if (!customer.Active)
                return null;

            if (!customer.CustomerRoles.Any())
                return null;

            if (!customer.CustomerRoles.Any(a=>a.CustomerRoleId == customerRoleId))
                return null;

            var token = await GetTokenByCustomerId(customerId);

            if (token != null && token.ExpiresOn > DateTime.Now)
            {
                token.ExpiresOn = DateTime.Now.AddMinutes(30);
                await _tokenManagerRepository.Update(token);
                return _mapper.Map<CustomerModel>(customer);
            }
            return null;
        }

        public async Task<TokenManager> GetTokenByCustomerId(int customerId)
        {
            return await _tokenManagerRepository.Table.FirstOrDefaultAsync(a => a.CustomerId == customerId);
        }

        public async Task<TokenManager> GetTokenById(int id)
        {
            return await _tokenManagerRepository.GetById(id);
        }

        public async Task DeleteToken(TokenManager token)
        {
            await _tokenManagerRepository.Delete(token);
        }

        public async Task InsertToken(TokenManager token)
        {
            await _tokenManagerRepository.Insert(token);
        }


        public async Task<LoginResponseModel> GetLoginResponse(CustomerModel customer)
        {
            var customerDetails = await (from customerTable in _customerRepository.Table
                                   join customerRoleMapping in _customerCustomerRoleRepository.Table on customerTable.Id equals customerRoleMapping.CustomerId
                                   join customerRole in _customerRoleRepository.Table on customerRoleMapping.CustomerRoleId equals customerRole.Id
                                   where customerTable.Id == customer.Id
                                   select new
                                   {
                                       CustomerId = customerTable.Id,
                                       Username = customerTable.UserName,
                                       CustomerTypeId = customerRoleMapping.CustomerRoleId,
                                       CustomerTypeName = customerRole.Name,
                                   }).ToListAsync();

            if (customerDetails == null)
                return null;

            var tokenModel = new CustomerLoginTokenModel();
            foreach (var item in customerDetails)
            {
                tokenModel.CustomerId = item.CustomerId;
                tokenModel.UserName = item.Username;
                tokenModel.CustomerRoleIds.Add(item.CustomerTypeId);
                tokenModel.CustomerRoleNames.Add(item.CustomerTypeName);
            }
            return await GenerateToken(tokenModel);
        }

        public async Task<LoginResponseModel> GenerateToken(CustomerLoginTokenModel tokenModel)
        {
            try
            {
                var token = await GetTokenByCustomerId(tokenModel.CustomerId);

                if (token != null)
                    await DeleteToken(token);

                var newToken = new TokenManager
                {
                    Id = 0,
                    TokenKey = KeyGenerator.GenerateToken(tokenModel),
                    IssuedOn = DateTime.Now,
                    ExpiresOn = DateTime.Now.AddMinutes(30),
                    CustomerId = tokenModel.CustomerId,
                    CreatedBy = tokenModel.CustomerId,
                    CreatedOn = DateTime.Now
                };

                await InsertToken(newToken);

                return new LoginResponseModel
                {
                    UserName = tokenModel.UserName,
                    Token = newToken.TokenKey,
                    CustomerTypeIds = string.Join(",", tokenModel.CustomerRoleIds.ToArray()),
                    IsAdmin = tokenModel.CustomerRoleIds.Contains((int)CustomerRoleEnum.Admin)
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
