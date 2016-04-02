using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DI.PoorMansContainer.DIContainer
{
    public class Container
    {
        public Container()
        {
            _registrations = new List<ContainerItem>();
        }

        public void Register<T, TU>()
            where TU : class, new()
        {
            Type abstractionType = typeof(T);
            Type concreteType = typeof(TU);

            Register(abstractionType, concreteType);
        }

        public void Register(Type abstractionType, Type concreteType)
        {
            if (!abstractionType.IsInterface)
            {
                throw new ApplicationException("First generic argument must be an interface type.");
            }

            _registrations.Add(new ContainerItem
            {
                AbstractionType = abstractionType, 
                ConcreteType = concreteType
            });
        }

        private readonly List<ContainerItem> _registrations;

        public T CreateType<T>() where T : class
        {
            Type type = typeof(T);

            return (T)GetConcreteType(type);
        }

        public object CreateType(Type type)
        {
            return GetConcreteType(type);
        }

        private object GetConcreteType(Type typeToResolve)
        {
            ContainerItem containerItem = _registrations.FirstOrDefault(item => item.AbstractionType == typeToResolve);

            return GetTypeInstance(containerItem != null ? containerItem.ConcreteType : typeToResolve);
        }

        private object GetTypeInstance(Type type)
        {
            object instance = null;

            ConstructorInfo[] constructors = type.GetConstructors();

            if (constructors.Length > 0)
            {
                ConstructorInfo constructor = constructors[0];

                List<object> constructorArguments = new List<object>();

                ParameterInfo[] parameters = constructor.GetParameters();

                foreach (ParameterInfo parameter in parameters)
                {
                    object parameterInstance = null;

                    if (parameter.ParameterType.IsInterface)
                        // recursion happens here
                        parameterInstance = GetConcreteType(parameter.ParameterType);

                    constructorArguments.Add(parameterInstance);
                }

                instance = Activator.CreateInstance(type, constructorArguments.ToArray());
            }

            return instance;
        }
    }
}
