using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store;

namespace PlatformAdapter.WindowsStore
{
    public class AppInfo : IAppInfo
    {
        private LicenseInformation _licenseInfo = null;

        public AppInfo()
        {
            var ver = global::Windows.ApplicationModel.Package.Current.Id.Version;
            this.VersionNumber = new Version(ver.Major, ver.Minor, ver.Build, ver.Revision);
        }

        public void Initialize()
        {
            //todo: a better way to get compile-time http://www.codinghorror.com/blog/2005/04/determining-build-date-the-hard-way.html
//            this.CompiledDate = new DateTime(this.VersionNumber.Build * TimeSpan.TicksPerDay + this.VersionNumber.Revision * TimeSpan.TicksPerSecond * 2).AddYears(1999);

#if DEBUG
            _licenseInfo = Windows.ApplicationModel.Store.CurrentAppSimulator.LicenseInformation;
#else
            _licenseInfo = global::Windows.ApplicationModel.Store.CurrentApp.LicenseInformation;
#endif
        }

        public bool IsTrial
        {
            get { return _licenseInfo.IsTrial; }
        }

        public bool IsTrialExpired
        {
            get { return (_licenseInfo.IsActive == false); }
        }

        public DateTime TrialExpirationDate
        {
            get { return _licenseInfo.ExpirationDate.DateTime; }
        }

        public string Name
        {
            get;
            private set;
        }

        public string NameLocalized
        {
            get;
            private set;
        }

        public Version VersionNumber
        {
            get;
            private set;
        }

        public DateTime CompiledDate
        {
            get;
            private set;
        }

        public string SupportEmailAddress
        {
            get;
            private set;
        }

        public DateTime InstallDate
        {
            get;
            private set;
        }
    }
}
