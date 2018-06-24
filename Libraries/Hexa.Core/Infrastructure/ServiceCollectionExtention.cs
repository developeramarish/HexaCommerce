using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Hexa.Core.Infrastructure
{
    public static class ServiceCollectionExtention
    {
        public static IServiceProvider RegisterServices(this IServiceCollection services)
        {
            var containerBuilder = new ContainerBuilder();

            var types = AppDomain.CurrentDomain.GetAssemblies()
                                    .Where(a => !a.IsDynamic)
                                    .SelectMany(a => a.GetTypes())
                                    .Where(t => typeof(IDependencyRegistrar).IsAssignableFrom(t));

            var instances = types.Where(d => d.IsClass)
                .Select(d => (IDependencyRegistrar)Activator.CreateInstance(d));

            foreach (var instance in instances)
            {
                instance.Register(containerBuilder);
            }

            containerBuilder.Populate(services);

            return new AutofacServiceProvider(containerBuilder.Build());
        }
    }
}
