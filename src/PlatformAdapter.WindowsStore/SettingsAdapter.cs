using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;

namespace PlatformAdapter.WindowsStore
{
    public class SettingsAdapter : ISettingsAdapter
    {
        Lazy<PasswordVault> vault = new Lazy<PasswordVault>();

        public SettingsAdapter()
        {
            
        }

        public void SaveCredential(SavedCredential credential)
        {
            //todo: need to check if pwd is already in the value?

            vault.Value.Add(new PasswordCredential(credential.Resource, credential.UserName, credential.Password));
        }

        public IEnumerable<SavedCredential> LoadCredential(string resource)
        {
            return vault.Value.FindAllByResource(resource).Select(x => new SavedCredential { Resource = x.Resource, Password = x.Password, UserName = x.UserName });
        }

        public SavedCredential LoadCredential(string resource, string username)
        {
            var c = vault.Value.Retrieve(resource, username);
            return new SavedCredential { Resource = c.Resource, Password = c.Password, UserName = c.UserName };
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

        public void SaveCredential(string identifier, SavedCredential credential)
        {
            throw new NotImplementedException();
        }


        public bool TryGetCredential(string identifier, out SavedCredential credential)
        {
            throw new NotImplementedException();
        }

        public bool TryGetLocal<T>(string identifier, out T value)
        {
            throw new NotImplementedException();
        }

        public bool TryGetRoaming<T>(string identifier, out T value)
        {
            throw new NotImplementedException();
        }
    }
}

namespace PlatformAdapter
{
    public static class SettingsExtensions
    {
        public static SavedCredential AsSavedCredential(this PasswordCredential credential)
        {
            if (null != credential)
            {
                return new SavedCredential { Resource = credential.Resource, UserName = credential.UserName, Password = credential.Password };
            }

            return null;
        }

        public static PasswordCredential AsPasswordCredential(this SavedCredential credential)
        {
            if (null != credential)
            {
                return new PasswordCredential(credential.Resource, credential.UserName, credential.Password );
            }

            return null;
        }
    }
}