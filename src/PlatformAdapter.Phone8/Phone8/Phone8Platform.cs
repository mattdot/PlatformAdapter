using PlatformAdapter.Phone8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter
{
    public static class Phone8Platform //: IPlatform
    {
        public static void Initialize(this Platform platform)
        {
            new Phone8PlatformBuilder().Build(platform);
            //platform.Locator.RegisterType<IBackgroundAudio, BackgroundAudio>();
        }
    }
}

namespace PlatformAdapter.Phone8
{
    public class Phone8PlatformBuilder : PlatformAdapter.IPlatformBuilder
    {
        public void Build(Platform platform)
        {
            //platform.Locator.RegisterType<IBackgroundAudio, BackgroundAudio>();
            platform.Locator.RegisterType<IStorageAdapter, StorageAdapter>();
            platform.Locator.RegisterType<ISettingsAdapter, SettingsAdapter>();
            platform.Locator.RegisterType<IGeolocationAdapter, GeolocationAdapter>();
        }
    }

}