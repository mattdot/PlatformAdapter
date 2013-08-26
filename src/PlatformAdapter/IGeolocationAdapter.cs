using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter
{
    public interface IGeolocationAdapter : IPlatformAdapter
    {
        bool LocationConsent { get; set; }

        Task<IGeoposition> GetLocationAsync(GeolocationOptions options);
        void StartTracking(GeolocationOptions options);

        event EventHandler PositionChanged;
        event EventHandler StatusChanged;
    }

    public interface IGeoposition
    {
    }

    public sealed class GeolocationOptions
    {
        public bool HighAccuracy { get; set; }
    }
}
