using AutoMapper;
using Hexa.Business.Models.Catalog;
using Hexa.Business.Models.Customers;
using Hexa.Core.Domain.Catalog;
using Hexa.Core.Domain.Customers;

namespace Hexa.Business
{
    public static class AutoMapper
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, CategoryModel>().ReverseMap();
                cfg.CreateMap<Customer, CustomerModel>().ReverseMap();
            });
        }
    }
}
