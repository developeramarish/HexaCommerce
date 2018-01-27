using System;
using Hexa.Core.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Hexa.Data.Test
{
    [TestClass]
    public class CategoryTest : HexaDbContext
    {
        [TestMethod]
        public void CreateDatabaseAndData()
        {
            using (var context = new HexaDbContext())
            {
                context.Database.EnsureCreatedAsync();

                // categories
                //context.Entry(new Category { Name = "Electronics", Active = true, CreatedOn = DateTime.UtcNow, Deleted = false, Description = "Electronics Category", DisplayOrder = 1, IncludeInNavigation = true, ParentCategoryId = 0 }).State = EntityState.Added;
                //context.Entry(new Category { Name = "Mobile", Active = true, CreatedOn = DateTime.UtcNow, Deleted = false, Description = "Electronics Category", DisplayOrder = 1, IncludeInNavigation = true, ParentCategoryId = 1 }).State = EntityState.Added;
                //context.Entry(new Category { Name = "Television", Active = true, CreatedOn = DateTime.UtcNow, Deleted = false, Description = "Electronics Category", DisplayOrder = 1, IncludeInNavigation = true, ParentCategoryId = 1 }).State = EntityState.Added;
                //context.Entry(new Category { Name = "Refridgerator", Active = true, CreatedOn = DateTime.UtcNow, Deleted = false, Description = "Electronics Category", DisplayOrder = 1, IncludeInNavigation = true, ParentCategoryId = 1 }).State = EntityState.Added;
                //context.Entry(new Category { Name = "Furniture", Active = true, CreatedOn = DateTime.UtcNow, Deleted = false, Description = "Electronics Category", DisplayOrder = 1, IncludeInNavigation = true, ParentCategoryId = 0 }).State = EntityState.Added;
                //context.Entry(new Category { Name = "Kitchen Appliances", Active = true, CreatedOn = DateTime.UtcNow, Deleted = false, Description = "Electronics Category", DisplayOrder = 1, IncludeInNavigation = true, ParentCategoryId = 0 }).State = EntityState.Added;
                //context.Entry(new Category { Name = "Vehicles", Active = true, CreatedOn = DateTime.UtcNow, Deleted = false, Description = "Electronics Category", DisplayOrder = 1, IncludeInNavigation = true, ParentCategoryId = 0 }).State = EntityState.Added;
                //context.Entry(new Category { Name = "Bike", Active = true, CreatedOn = DateTime.UtcNow, Deleted = false, Description = "Electronics Category", DisplayOrder = 1, IncludeInNavigation = true, ParentCategoryId = 7 }).State = EntityState.Added;
                //context.Entry(new Category { Name = "Car", Active = true, CreatedOn = DateTime.UtcNow, Deleted = false, Description = "Electronics Category", DisplayOrder = 1, IncludeInNavigation = true, ParentCategoryId = 7 }).State = EntityState.Added;

                // default customer
                context.Entry(new Customer { FirstName = "Krutal", LastName = "Modi", UserName = "admin@admin.com", Email="admin@admin.com", Password="admin", Active = true, Deleted = false, CreatedOn = DateTime.UtcNow, FailedLoginAttempts = 0, DisplayOrder = 0 }).State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }


}
