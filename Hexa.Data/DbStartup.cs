using System;
using System.Linq;
using System.Threading.Tasks;
using Hexa.Core;
using Hexa.Core.Data;
using Hexa.Core.Domain.Customers;

namespace Hexa.Data
{
    public partial class DbStartup
    {
        public static void Seed(HexaDbContext _context)
        {
            if (!_context.Customers.Any())
            {
                _context.AddRange
                (
                    // Employee 
                    new Customer { FirstName = "Krutal", LastName = "Modi", Email = "krutal.modi89@gmail.com", UserName = "kmodi", Password = EncryptionLibrary.EncryptText("adminadmin"), CreatedOn = DateTime.Now, Active = true },
                    new Customer { FirstName = "Dharmik", LastName = "Bhandari", Email = "dharmik.bhandari@gmail.com", UserName = "dharmik", Password = EncryptionLibrary.EncryptText("dharmikdharmik"), CreatedOn = DateTime.Now, Active = true },

                    // Employee Role
                    new CustomerRole { Name = "Admin", DisplayOrder = 0 },
                    new CustomerRole { Name = "Registered", DisplayOrder = 1 }

                    // Employee Role Mapping
                    //new CustomerCustomerRole { CustomerId = 1, CustomerRoleId = 1 },
                    //new CustomerCustomerRole { CustomerId = 2, CustomerRoleId = 2 }
                );

                _context.SaveChanges();
            }
        }
    }
}
