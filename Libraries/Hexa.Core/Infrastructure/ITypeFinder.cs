using System;
using System.Collections.Generic;
using System.Reflection;

namespace Hexa.Core.Infrastructure
{
    public interface ITypeFinder
    {
        IEnumerable<Type> FindClassesOfType(Type typeName, bool onlyConcreteClasses);

        IList<Assembly> GetAssemblies();
    }
}
