using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter
{
    public interface IAnalyticsAdapter : IPlatformAdapter
    {
        void NewPageView(Type pageType);
        void Event(string eventName, params KeyValuePair<string, object>[] pairs);
        void Error(string message, Exception ex);
        //void SetCurrentLocation(LocationInfo location);
        void SetUsername(string username);
    }
}
