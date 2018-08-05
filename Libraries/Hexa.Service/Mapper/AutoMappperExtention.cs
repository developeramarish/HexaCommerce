using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Hexa.Service.Mapper
{
    public static class AutoMappperExtention
    {
        public static void RegisterMapper(this IServiceCollection services)
        {
            //create AutoMapper configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            //register
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
