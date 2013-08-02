using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatformAdapter
{
    internal sealed class SimpleServiceLocator : IServiceLocator
    {
        private Dictionary<Type, object> factories = new Dictionary<Type, object>();

        public void RegisterType<TInterface, TImplementation>() where TImplementation : TInterface, new() 
        {
            this.RegisterType<TInterface>(() => (TInterface)(new TImplementation()));
        }

        public void RegisterType<T>(Func<T> factory)
        {
            this.factories[typeof(T)] = factory;
        }

        public void RegisterInstance<T>(T instance)
        {
            this.factories[typeof(T)] = (Func<T>)(() => instance);
        }

        public T Resolve<T>()
        {
            object f;

            if (this.factories.TryGetValue(typeof(T), out f))
            {
                return ((Func<T>)f)();
            }

            return default(T);
        }
    }
}
