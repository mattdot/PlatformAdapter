using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter
{
    public interface INavigationAdapter : IPlatformAdapter
    {
        void NavigateToModel(object model, object parameter = null);
        void NavigateTo(Uri address);
        void NavigateTo(string address);
    }
}
