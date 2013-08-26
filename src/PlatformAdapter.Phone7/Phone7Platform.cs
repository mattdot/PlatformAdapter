using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatformAdapter.Phone7
{
    public sealed class Phone7Platform : IPlatform
    {
        public void Initialize()
        {
            Platform.Current.Locator.RegisterType<IStorageAdapter>(() => new StorageAdapter());
        }
    }

    public static class Phone7PlatformExtensions
    {

    }
}
