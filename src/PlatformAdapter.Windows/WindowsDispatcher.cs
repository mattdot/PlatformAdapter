using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace PlatformAdapter.Windows
{
    internal sealed class WindowsDispatcher : IDispatcher
    {
        public Task RunAsync(Action action)
        {
            return Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, new DispatchedHandler(action)).AsTask();
        }
    }
}
