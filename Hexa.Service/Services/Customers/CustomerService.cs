using Hexa.Service.Contracts.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using Hexa.Core.Domain.Customers;
using Hexa.Core.Data;
using Hexa.Business.Models.Customers;
using AutoMapper;
using Hexa.Service.Authentication;
using Hexa.Core;
using Hexa.Business;
using Microsoft.EntityFrameworkCore;

namespace Hexa.Service.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        #region Fields

        private readonly IHexaRepository<Customer> _customerRepository;
        private readonly IHexaRepository<TokenManager> _tokenManagerRepository;
        private readonly IHexaRepository<CustomerRole> _customerRoleRepository;
        private readonly IHexaRepository<CustomerCustomerRole> _customerCustomerRoleRepository;

        #endregion

        #region Ctor

        public CustomerService(IHexaRepository<Customer> customerRepository,
            IHexaRepository<TokenManager> tokenManagerRepository,
            IHexaRepository<CustomerRole> customerRoleRepository,
            IHexaRepository<CustomerCustomerRole> customerCustomerRoleRepository)
        {
            _customerRepository = customerRepository;
            _tokenManagerRepository = tokenManagerRepository;
            _customerRoleRepository = customerRoleRepository;
            _customerCustomerRoleRepository = customerCustomerRoleRepository;
        }

        #endregion

        #region Methods

        public void DeleteCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("Customer");

            customer.Deleted = true;
            UpdateCustomer(customer);
        }

        public Customer GetCustomerById(int customerId)
        {
            if (customerId == 0)
                return null;

            return _customerRepository.GetById(customerId);
        }

        public void InsertCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("Customer");

            _customerRepository.Insert(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("Customer");

            _customerRepository.Update(customer);
        }

        public IList<Customer> GetAllCustomers(string name)
        {
            var query = _customerRepository.Table;
            query = query.Where(c => c.Active);
            query = query.Where(c => !c.Deleted);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.FirstName.Contains(name));

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.LastName.Contains(name));

            return query.OrderBy(a => a.DisplayOrder).ToList();
        }

        public Customer GetCustomerByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            var query = from c in _customerRepository.Table
                        orderby c.Id
                        where c.Email == email
                        select c;
            var customer = query.FirstOrDefault();
            return customer;
        }

        public virtual Customer GetCustomerByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            var query = from c in _customerRepository.Table
                        orderby c.Id
                        where c.UserName == username
                        select c;
            var customer = query.FirstOrDefault();
            return customer;
        }

        public CustomerModel ValidateCustomer(string username, string password)
        {
            var customer = GetCustomerByUsername(username);

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
                UpdateCustomer(customer);
                return null;
            }

            return Mapper.Map<CustomerModel>(customer);
        }

        public CustomerModel ValidateCustomerRole(int customerId, int customerRoleId)
        {
            var customer = _customerRepository.Table.Include(a => a.CustomerRoles).FirstOrDefault(a=>a.Id == customerId);

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

            var token = GetTokenByCustomerId(customerId);

            if (token != null && token.ExpiresOn > DateTime.Now)
                return Mapper.Map<CustomerModel>(customer);

            return null;
        }

        public TokenManager GetTokenByCustomerId(int customerId)
        {
            return _tokenManagerRepository.Table.FirstOrDefault(a => a.CustomerId == customerId);
        }

        public TokenManager GetTokenById(int id)
        {
            return _tokenManagerRepository.GetById(id);
        }

        public void DeleteToken(TokenManager token)
        {
            _tokenManagerRepository.Delete(token);
        }

        public void InsertToken(TokenManager token)
        {
            _tokenManagerRepository.Insert(token);
        }


        public LoginResponseModel GetLoginResponse(CustomerModel customer)
        {
            var customerDetails = (from customerTable in _customerRepository.Table
                                   join customerRoleMapping in _customerCustomerRoleRepository.Table on customerTable.Id equals customerRoleMapping.CustomerId
                                   join customerRole in _customerRoleRepository.Table on customerRoleMapping.CustomerRoleId equals customerRole.Id
                                   where customerTable.Id == customer.Id
                                   select new
                                   {
                                       CustomerId = customerTable.Id,
                                       Username = customerTable.UserName,
                                       CustomerTypeId = customerRoleMapping.CustomerRoleId,
                                       CustomerTypeName = customerRole.Name,
                                   }).ToList();

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
            return GenerateToken(tokenModel);
        }

        public LoginResponseModel GenerateToken(CustomerLoginTokenModel tokenModel)
        {
            try
            {
                var token = GetTokenByCustomerId(tokenModel.CustomerId);

                if (token != null)
                    DeleteToken(token);

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

                InsertToken(newToken);

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
