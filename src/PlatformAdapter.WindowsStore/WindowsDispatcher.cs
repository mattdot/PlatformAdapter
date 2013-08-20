using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace PlatformAdapter.WindowsStore
{
    internal sealed class WindowsDispatcher : IDispatcherAdapter
    {
        public Task RunAsync(Action action)
        {
            return Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, new DispatchedHandler(action)).AsTask();
        }
    }
}
