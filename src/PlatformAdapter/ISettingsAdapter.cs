using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace PlatformAdapter
{
    public interface ISettingsAdapter
    {
        void SaveCredential(string identifier, SavedCredential credential);
        bool TryGetCredential(string identifier, out SavedCredential credential);
        void SaveLocal<T>(string identifier, T value);
        bool TryGetLocal<T>(string identifier, out T value);
        void SaveRoaming<T>(string identifier, T value);
        bool TryGetRoaming<T>(string identifier, out T value);


    }

    public sealed class SavedCredential
    {
        public string Resource { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public static class SettingsAdapterExtensions
    {
        public static T GetLocal<T>(this ISettingsAdapter settings, string identifier, T defaultValue = default(T))
        {
            T val;
            if (!settings.TryGetLocal<T>(identifier, out val))
            {
                return defaultValue;
            }

            return val;
        }
    }
}
