using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if WINDOWS || WP8 || NETFX_CORE
using System.Runtime.CompilerServices;
[assembly: TypeForwardedTo(typeof(System.Lazy<>))]
#else
namespace System
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>
    /// Have to implement this because win7.5 doesn't support it.
    /// </remarks>
    public class Lazy<T>
    {
        private T value;
        private Func<T> factory;

        public bool IsValueCreated { get; private set; }

        public Lazy(Func<T> factory)
        {
            this.factory = factory;
        }

        public T Value
        {
            get
            {
                if (!this.IsValueCreated)
                {
                    this.value = this.factory();
                }

                return this.value;
            }
        }
    }
}
#endif