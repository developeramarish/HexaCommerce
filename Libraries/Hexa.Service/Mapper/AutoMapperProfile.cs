using AutoMapper;
using Hexa.Business.Models.Catalog;
using Hexa.Business.Models.Customers;
using Hexa.Business.Models.Logs;
using Hexa.Business.Models.Pictures;
using Hexa.Core.Domain.Catalog;
using Hexa.Core.Domain.Customers;
using Hexa.Core.Domain.Logs;
using Hexa.Core.Domain.Pictures;

namespace Hexa.Service.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<CustomerModel, Customer>().ReverseMap();
            CreateMap<Log, LogModel>().ReverseMap();
            CreateMap<Picture, PictureModel > ().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<ProductCategoryMapping, ProductCategoryModel>().ReverseMap();
            CreateMap<ProductPictureMapping, ProductPictureModel>().ReverseMap();
        }
    }
}
