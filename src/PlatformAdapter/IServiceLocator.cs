using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatformAdapter
{
    public interface IServiceLocator
    {
        void RegisterType<TInterface, TImplementation>() where TImplementation : TInterface, new();
        void RegisterType<T>(Func<T> factory);
        void RegisterInstance<T>(T instance);
        T Resolve<T>();
    }
}