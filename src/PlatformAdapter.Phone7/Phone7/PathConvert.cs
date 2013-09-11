using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatformAdapter.Phone7
{
    // WINRT --> PHONE7
    // ms-appx:/// --> isostore:/
    // ms-appx-web
    // ms-resource:/// --> appdata:/
    //
    internal static class PathConvert
    {
        public static string ToWinRtPath(string path)
        {
            //todo: convert back
            return path;
        }

        public static string ToPhonePath(string path)
        {
            if (path == null)
            {
                return string.Empty;
            }

            path = path.Replace("ms-appx:///", "").Replace("isostore:/", "");

            while (path.StartsWith("/"))
            {
                if (path.Length == 1)
                {
                    path = string.Empty;
                }
                else
                {
                    path = path.Substring(1);
                }
            }

            return path.Trim();
        }
    }
}
