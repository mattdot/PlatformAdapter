using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatformAdapter
{
    public interface ILoggingAdapter
    {
        void Log(string message, params object[] args);
        void Log(Exception ex);
        void LogVerbose(string message, params object[] args);
        //void Log(HttpRequestMessage request, string description = null);
        //void Log(HttpResponseMessage response, string description = null);
    }
}
