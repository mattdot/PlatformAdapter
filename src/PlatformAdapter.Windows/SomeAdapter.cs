using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter.Windows
{
    public class SomeAdapter : ISomeAdapter
    {
        public string SaySomething()
        {
            return "Something Windows";
        }
    }
}
