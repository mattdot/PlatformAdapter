using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatformAdapter.Phone7
{
    public class GeolocatorAdapter : IGeolocationAdapter
    {

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
            throw new NotImplementedException();
        }

        public void StartTracking(GeolocationOptions options)
        {
            throw new NotImplementedException();
        }

        public event EventHandler PositionChanged;

        public event EventHandler StatusChanged;

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
