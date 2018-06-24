using Autofac;

namespace Hexa.Core.Infrastructure
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder);
    }
}