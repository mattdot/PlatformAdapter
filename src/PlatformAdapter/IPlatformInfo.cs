using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter
{
    public interface IPlatformInfo : IPlatformAdapter
    {
        string DeviceName { get; }
        string DeviceManufaturer { get; }
        string DeviceUniqueId { get; }
        string ProcessorType { get; }

        string OsPlatform { get; }
        Version OsVersion { get; }

        double DevicePixelsWidth { get; }
        double DevicePixelsHeight { get; }

        long DeviceTotalMemory { get; }

        T GetCustomProperty<T>(string key);
    }
}