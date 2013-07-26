using PlatformAdapter.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter
{
    public static class WindowsPlatform
    {
        public static void Initialize(this Platform platform)
        {
            platform.Register<ISomeAdapter, SomeAdapter>();
        }
    }
}
