using Android.App;
using Android.Content;
using Android.Locations;
using System;
namespace PlatformAdapter.Android
{
	public class Geolocator : ILocationListener, IGeolocationAdapter
	{
        LocationManager locmgr;
        Context ctx;

		public Geolocator()
		{
            this.ctx = global::Android.App.Application.Context;
            this.locmgr = ctx.GetSystemService(Context.LocationService) as LocationManager;
		}

        public bool LocationConsent
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Threading.Tasks.Task<IGeoposition> GetLocationAsync(GeolocationOptions options)
        {
            this.locmgr.RequestLocationUpdates(LocationManager.GpsProvider, 2000L, 1f, this);
            throw new NotImplementedException();
        }

        public void StartTracking(GeolocationOptions options)
        {
            throw new NotImplementedException();
        }

        public event EventHandler PositionChanged;

        public event EventHandler StatusChanged;


        void ILocationListener.OnLocationChanged(Location location)
        {
            throw new NotImplementedException();
        }

        void ILocationListener.OnProviderDisabled(string provider)
        {
            throw new NotImplementedException();
        }

        void ILocationListener.OnProviderEnabled(string provider)
        {
            throw new NotImplementedException();
        }

        void ILocationListener.OnStatusChanged(string provider, Availability status, global::Android.OS.Bundle extras)
        {
            throw new NotImplementedException();
        }

        IntPtr global::Android.Runtime.IJavaObject.Handle
        {
            get { throw new NotImplementedException(); }
        }


        #region IDisposable

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Geolocator()
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