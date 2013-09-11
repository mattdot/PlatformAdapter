using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatformAdapter.Phone7
{
    public sealed class Phone7PlatformBuilder : IPlatformBuilder
    {
        public void Build(Platform platform)
        {
            platform.Locator.RegisterType<IStorageAdapter>(() => new StorageAdapter());
            platform.Locator.RegisterType<ISettingsAdapter>(() => new SettingsAdapter());
        }
    }

    public static class Phone7PlatformExtensions
    {

    }
}
