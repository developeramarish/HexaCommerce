using Autofac;
using Hexa.Core.Data;
using Hexa.Core.Domain.Customers;
using Hexa.Core.Domain.Logs;
using Hexa.Core.Infrastructure;
using Hexa.Data;
using Hexa.Service.Contracts.Catalog;
using Hexa.Service.Contracts.Customers;
using Hexa.Service.Contracts.Logs;
using Hexa.Service.Contracts.Pictures;
using Hexa.Service.Services.Catalog;
using Hexa.Service.Services.Customers;
using Hexa.Service.Services.Logs;
using Hexa.Service.Services.Pictures;

namespace Hexa.Service.DependencyRegistrar
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(HexaRepository<>)).As(typeof(IHexaRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<HexaRepository<Customer>>().As<IHexaRepository<Customer>>().InstancePerLifetimeScope();
            builder.RegisterType<HexaRepository<Log>>().As<IHexaRepository<Log>>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<LogService>().As<ILogService>().InstancePerLifetimeScope();
            builder.RegisterType<PictureService>().As<IPictureService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
        }
    }
}
