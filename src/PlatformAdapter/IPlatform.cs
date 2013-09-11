using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatformAdapter
{
    public interface IPlatformBuilder
    {
        void Build(Platform platform);
    }
}
