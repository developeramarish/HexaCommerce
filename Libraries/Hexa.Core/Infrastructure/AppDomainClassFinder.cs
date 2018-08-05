using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Hexa.Core.Infrastructure
{
    public class AppDomainClassFinder : ITypeFinder
    {
        public string AssemblySkipLoadingPattern { get; set; } = "^Hexa";

        public string AssemblyRestrictToLoadingPattern { get; set; } = ".*";

        public IList<string> AssemblyNames { get; set; } = new List<string>();

        public IEnumerable<Type> FindClassesOfType(Type typeName, bool onlyConcreteClasses)
        {
            var assemblies = GetAssemblies();
            var result = new List<Type>();
            try
            {
                foreach (var a in assemblies)
                {
                    Type[] types = null;
                    try
                    {
                        types = a.GetTypes();
                    }
                    catch
                    {
                    }

                    if (types == null)
                        continue;

                    foreach (var t in types)
                    {
                        if (!typeName.IsAssignableFrom(t) && (!typeName.IsGenericTypeDefinition || !DoesTypeImplementOpenGeneric(t, typeName)))
                            continue;

                        if (t.IsInterface)
                            continue;

                        if (onlyConcreteClasses)
                        {
                            if (t.IsClass && !t.IsAbstract)
                            {
                                result.Add(t);
                            }
                        }
                        else
                        {
                            result.Add(t);
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                var msg = string.Empty;
                foreach (var e in ex.LoaderExceptions)
                    msg += e.Message + Environment.NewLine;

                var fail = new Exception(msg, ex);
                Debug.WriteLine(fail.Message, fail);

                throw fail;
            }

            return result;
        }

        protected virtual bool DoesTypeImplementOpenGeneric(Type type, Type openGeneric)
        {
            try
            {
                var genericTypeDefinition = openGeneric.GetGenericTypeDefinition();
                foreach (var implementedInterface in type.FindInterfaces((objType, objCriteria) => true, null))
                {
                    if (!implementedInterface.IsGenericType)
                        continue;

                    var isMatch = genericTypeDefinition.IsAssignableFrom(implementedInterface.GetGenericTypeDefinition());
                    return isMatch;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        private void AddAssembliesInAppDomain(List<string> addedAssemblyNames, List<Assembly> assemblies)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (string dll in Directory.GetFiles(path, "*.dll"))
            {
                if (!Matches(Assembly.LoadFile(dll).FullName, AssemblySkipLoadingPattern))
                    continue;

                assemblies.Add(Assembly.LoadFile(dll));
            }
        }

        protected virtual bool Matches(string assemblyFullName, string pattern)
        {
            return Regex.IsMatch(assemblyFullName, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        protected virtual void AddConfiguredAssemblies(List<string> addedAssemblyNames, List<Assembly> assemblies)
        {
            foreach (var assemblyName in AssemblyNames)
            {
                var assembly = Assembly.Load(assemblyName);
                if (addedAssemblyNames.Contains(assembly.FullName))
                    continue;

                assemblies.Add(assembly);
                addedAssemblyNames.Add(assembly.FullName);
            }
        }

        public virtual bool Matches(string assemblyFullName)
        {
            return Matches(assemblyFullName, AssemblySkipLoadingPattern)
                   && Matches(assemblyFullName, AssemblyRestrictToLoadingPattern);
        }

        public IList<Assembly> GetAssemblies()
        {
            var addedAssemblyNames = new List<string>();
            var assemblies = new List<Assembly>();

            AddAssembliesInAppDomain(addedAssemblyNames, assemblies);

            return assemblies;
        }
    }
}
