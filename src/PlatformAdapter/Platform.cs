using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlatformAdapter
{
    /// <summary>
    /// we should use a real dependency injection framework/implementation or MEF.  This is a hack
    /// </summary>
    public class Platform
    {
        private static readonly Platform current = new Platform();

        public static Platform Current
        {
            get
            {
                return Platform.current;
            }
        }

        private Platform()
        {

        }

        private Dictionary<Type, Type> typeMap = new Dictionary<Type, Type>();

        public void Register<TInterface, TImplementation>() where TImplementation : new()
        {
            //todo: make sure implementation implements interface

            this.typeMap[typeof(TInterface)] = typeof(TImplementation);
        }

        public T GetAdapter<T>()
        {
            Type imp;

            if (this.typeMap.TryGetValue(typeof(T), out imp))
            {
                return (T) Activator.CreateInstance(imp);
            }
            else
            {
                return default(T);
            }
        }
    }
}
