using PlatformAdapter.WindowsStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace PlatformAdapter
{

    public static class WindowsPlatform
    {
        public static void Initialize(this Platform platform)
        {
            platform.Locator.RegisterType<IDispatcherAdapter>(() => new WindowsDispatcher());
            platform.Locator.RegisterType<ICryptographyAdapter>(() => new CryptographyAdapter());
            platform.Locator.RegisterType<IStorageAdapter>(() => new StorageAdapter());
        }

        public static void Configure<T>(this Platform platform, MediaElement mediaElement) where T : IBackgroundAudio
        {
            platform.Locator.RegisterInstance<MediaElement>(mediaElement);
            platform.Locator.RegisterType<IBackgroundAudio>(() => new BackgroundAudio(platform.Locator.Resolve<MediaElement>()));

        }
    }

    public sealed class WindowsStorePlatformBuilder : IPlatformBuilder
    {
        public void Build(Platform platform)
        {
            platform.Locator.RegisterType<IDispatcherAdapter>(() => new WindowsDispatcher());
            platform.Locator.RegisterType<ICryptographyAdapter>(() => new CryptographyAdapter());
            platform.Locator.RegisterType<IStorageAdapter>(() => new StorageAdapter());
        }
    }
}
