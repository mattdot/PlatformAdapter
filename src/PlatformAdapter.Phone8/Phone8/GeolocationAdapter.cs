using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace PlatformAdapter.Phone8
{
    public class Geoposition : IGeoposition
    {
        public Geoposition(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public double Latitude
        {
            get;
            private set;
        }

        public double Longitude
        {
            get;
            private set;
        }
    }

    public sealed class GeolocationAdapter : IGeolocationAdapter
    {
        public bool LocationConsent
        {
            get;
            set;
        }

        public async Task<IGeoposition> GetLocationAsync(GeolocationOptions options)
        {
            Geolocator geo = new Geolocator();
            var position = await geo.GetGeopositionAsync();
            return new Geoposition(position.Coordinate.Latitude, position.Coordinate.Longitude);
        }

        public void StartTracking(GeolocationOptions options)
        {
            
        }

        public event EventHandler PositionChanged;

        public event EventHandler StatusChanged;

        public void Dispose()
        {
        }
    }
}
