using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store;
using Windows.Storage;
using Windows.Storage.Streams;
using System.Runtime.InteropServices.WindowsRuntime;

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

        //public static async Task<DateTimeOffset?> RetrieveLinkerTimestamp(Assembly assembly)
        //{
        //    var pkg = Windows.ApplicationModel.Package.Current;
        //    if(null == pkg)
        //    {
        //        return null;
        //    }

        //    var assemblyFile = await pkg.InstalledLocation.GetFileAsync(assembly.ManifestModule.Name);
        //    if(null == assemblyFile)
        //    {
        //        return null;
        //        //todo: this shouldn't happen
        //    }

        //    var buffer = await FileIO.ReadBufferAsync(assemblyFile);
        //    using(var reader = DataReader.FromBuffer(buffer))
        //    {
        //        const int PeHeaderOffset = 60;
        //        const int LinkerTimestampOffset = 8;

        //        //read first 2048 bytes from the assembly file.
        //        byte[] b = new byte[2048];                
        //        reader.ReadBytes(b);

        //        //get the pe header offset
        //        int i = System.BitConverter.ToInt32(b, PeHeaderOffset);

        //        //read the linker timestamp from the PE header
        //        int secondsSince1970 = System.BitConverter.ToInt32(b, i + LinkerTimestampOffset);

        //        var dt = new DateTimeOffset(1970, 1, 1, 0, 0, 0, DateTimeOffset.Now.Offset) + DateTimeOffset.Now.Offset;
        //        return dt.AddSeconds(secondsSince1970);
        //    }
        //}

        public static async Task<DateTimeOffset?> RetrieveLinkerTimestamp(Assembly assembly)
        {
            var pkg = Windows.ApplicationModel.Package.Current;
            if (null == pkg)
            {
                return null;
            }

            var assemblyFile = await pkg.InstalledLocation.GetFileAsync(assembly.ManifestModule.Name);
            if (null == assemblyFile)
            {
                return null;
            }

            using (var stream = await assemblyFile.OpenSequentialReadAsync())
            {
                using (var reader = new DataReader(stream))
                {
                    const int PeHeaderOffset = 60;
                    const int LinkerTimestampOffset = 8;

                    //read first 2048 bytes from the assembly file.
                    byte[] b = new byte[2048];
                    await reader.LoadAsync((uint)b.Length);
                    reader.ReadBytes(b);
                    reader.DetachStream();

                    //get the pe header offset
                    int i = System.BitConverter.ToInt32(b, PeHeaderOffset);

                    //read the linker timestamp from the PE header
                    int secondsSince1970 = System.BitConverter.ToInt32(b, i + LinkerTimestampOffset);

                    var dt = new DateTimeOffset(1970, 1, 1, 0, 0, 0, DateTimeOffset.Now.Offset) + DateTimeOffset.Now.Offset;
                    return dt.AddSeconds(secondsSince1970);
                }
            }
        }

        #region IDisposable

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~AppInfo()
        {
            this.Dispose(false);
        }

        protected bool IsDisposed { get; private set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.IsDisposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                }

                //dispose unmanaged resources

                this.IsDisposed = true;
            }
        }

        #endregion
    }
}
