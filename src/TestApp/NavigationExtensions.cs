using PlatformAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public static class NavigationExtensions
    {
        public static void Home(this INavigationAdapter nav, bool clearBackstack = false)
        {
            nav.NavigateTo(new Uri(""));
        }
    }
}
