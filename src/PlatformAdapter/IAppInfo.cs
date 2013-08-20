using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter
{
    public interface IAppInfo : IPlatformAdapter
    {
        string Name { get; }
        string NameLocalized { get; }
        Version VersionNumber { get; }
        DateTime CompiledDate { get;  }
        string SupportEmailAddress { get; }
        bool IsTrial { get; }
        bool IsTrialExpired { get; }
        DateTime TrialExpirationDate { get; }
        DateTime InstallDate { get; }
    }
}
