using Autofac;
using Microsoft.Extensions.DependencyInjection;

namespace Hexa.Core.Infrastructure
{
    public interface IDependencyRegistrar
    {
        void Register(IServiceCollection builder);
    }
}