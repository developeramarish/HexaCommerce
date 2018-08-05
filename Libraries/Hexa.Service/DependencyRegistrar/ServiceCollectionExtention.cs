using Hexa.Core.Data;
using Hexa.Core.Domain.Catalog;
using Hexa.Core.Domain.Customers;
using Hexa.Core.Domain.Logs;
using Hexa.Core.Domain.Pictures;
using Hexa.Service.Contracts.Catalog;
using Hexa.Service.Contracts.Customers;
using Hexa.Service.Contracts.Logs;
using Hexa.Service.Contracts.Pictures;
using Hexa.Service.Services.Catalog;
using Hexa.Service.Services.Customers;
using Hexa.Service.Services.Logs;
using Hexa.Service.Services.Pictures;
using Microsoft.Extensions.DependencyInjection;
using Hexa.Data;
using Hexa.Core.Infrastructure;
using System.Linq;
using System;
using AutoMapper;

namespace Hexa.Service.DependencyRegistrar
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            var typeFinder = new AppDomainClassFinder();

            //register type finder
            services.AddSingleton<ITypeFinder>(typeFinder);

            //find dependency registrars classes added in all other assemblies
            var dependencyRegistrars = typeFinder.FindClassesOfType(typeof(IDependencyRegistrar), true);

            var instances = dependencyRegistrars
                .Select(d => (IDependencyRegistrar)Activator.CreateInstance(d))
                .OrderBy(a => a);

            foreach (var instance in instances)
            {
                instance.Register(services);
            }

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ILogService, LogService>();
            services.AddTransient<IPictureService, PictureService>();
            services.AddTransient<IProductService, ProductService>();

            services.AddSingleton(typeof(IHexaRepository<>), typeof(HexaRepository<>));
            services.AddTransient<IHexaRepository<Customer>, HexaRepository<Customer>>();
            services.AddTransient<IHexaRepository<CustomerRole>, HexaRepository<CustomerRole>>();
            services.AddTransient<IHexaRepository<CustomerCustomerRole>, HexaRepository<CustomerCustomerRole>>();
            services.AddTransient<IHexaRepository<TokenManager>, HexaRepository<TokenManager>>();
            services.AddTransient<IHexaRepository<Category>, HexaRepository<Category>>();
            services.AddTransient<IHexaRepository<Log>, HexaRepository<Log>>();
            services.AddTransient<IHexaRepository<Picture>, HexaRepository<Picture>>();
            services.AddTransient<IHexaRepository<Product>, HexaRepository<Product>>();
            services.AddTransient<IHexaRepository<ProductCategoryMapping>, HexaRepository<ProductCategoryMapping>>();
            services.AddTransient<IHexaRepository<ProductPictureMapping>, HexaRepository<ProductPictureMapping>>();

            return services;
        }
    }
}
