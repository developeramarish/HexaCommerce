using AutoMapper;
using Hexa.Business.Models.Catalog;
using Hexa.Business.Models.Customers;
using Hexa.Business.Models.Logs;
using Hexa.Core.Domain.Catalog;
using Hexa.Core.Domain.Customers;
using Hexa.Core.Domain.Logs;

namespace HexaCommerce
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<Log, LogModel>().ReverseMap();
        }
    }
}
