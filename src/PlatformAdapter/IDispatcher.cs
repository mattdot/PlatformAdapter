using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter
{
    public interface IDispatcher
    {
        Task RunAsync(Action action);
    }
}
