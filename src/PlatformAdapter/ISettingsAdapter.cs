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
        SavedCredential LoadCredential(string identifier);

        void SaveLocal<T>(string identifier, T value);
        T LoadLocal<T>(string identifier);
        void SaveRoaming<T>(string identifier, T value);
        T LoadRoaming<T>(string identifier);
    }

    public sealed class SavedCredential
    {
        public string Resource { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
