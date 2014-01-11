using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter.Phone8
{
    public sealed class SettingsAdapter : ISettingsAdapter
    {
        IsolatedStorageSettings settings;
        private readonly static RandomNumberGenerator random = new System.Security.Cryptography.RNGCryptoServiceProvider();

        public SettingsAdapter()
        {
            this.settings = IsolatedStorageSettings.ApplicationSettings;
        }

        public void SaveCredential(string identifier, SavedCredential credential)
        {
            var json = Serializer.Serialize(credential, SerializerFileTypes.Json);

            var cleartext = Encoding.UTF8.GetBytes(json);
            byte[] entropy = new byte[20];
            random.GetBytes(entropy);
            var cypher = ProtectedData.Protect(cleartext, entropy);

            this.SaveLocal<byte[]>(identifier, cypher);
            this.SaveLocal<byte[]>(identifier + "_entropy", entropy);
        }

        public bool TryGetCredential(string identifier, out SavedCredential credential)
        {
            byte[] cypher, entropy;
            if(!settings.TryGetValue<byte[]>(identifier, out cypher))
            {
                credential = null;
                return false;
            }

            if (!settings.TryGetValue<byte[]>(identifier + "_entropy", out entropy))
            {
                credential = null;
                return false;
            }

            byte[] cleartext = ProtectedData.Unprotect(cypher, entropy);
            credential = Serializer.Deserialize<SavedCredential>(Encoding.UTF8.GetString(cleartext, 0, cleartext.Length), SerializerFileTypes.Json);
            return true;
        }

        public void SaveLocal<T>(string identifier, T value)
        {
            this.settings[identifier] = value;
            this.settings.Save();
        }

        public bool TryGetLocal<T>(string identifier, out T value)
        {
            return this.settings.TryGetValue<T>(identifier, out value);
        }

        public void SaveRoaming<T>(string identifier, T value)
        {
            this.settings[identifier] = value;
            this.settings.Save();
        }

        public bool TryGetRoaming<T>(string identifier, out T value)
        {
            return this.settings.TryGetValue<T>(identifier, out value);
        }
    }
}
