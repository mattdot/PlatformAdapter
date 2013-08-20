using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatformAdapter
{
    /// <summary>
    /// Have to implement this because win7.5 doesn't support it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    //internal class Lazy<T>
    //{
    //    private T value;
    //    private Func<T> factory;

    //    public bool IsValueCreated { get; private set;}

    //    public Lazy(Func<T> factory)
    //    {
    //        this.factory = factory;
    //    }

    //    public T Value
    //    {
    //        get
    //        {
    //            if (!this.IsValueCreated)
    //            {
    //                this.value = this.factory();
    //            }

    //            return this.value;
    //        }
    //    }
    //}
}
