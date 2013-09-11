using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatformAdapter.Phone7
{
    public sealed class SettingsAdapter : ISettingsAdapter
    {
        public void SaveCredential(string identifier, SavedCredential credential)
        {
            throw new NotImplementedException();
        }

        public SavedCredential LoadCredential(string identifier)
        {
            throw new NotImplementedException();
        }

        public void SaveLocal<T>(string identifier, T value)
        {
            throw new NotImplementedException();
        }

        public T LoadLocal<T>(string identifier)
        {
            throw new NotImplementedException();
        }

        public void SaveRoaming<T>(string identifier, T value)
        {
            throw new NotImplementedException();
        }

        public T LoadRoaming<T>(string identifier)
        {
            throw new NotImplementedException();
        }
    }
}
