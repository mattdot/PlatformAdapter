//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PlatformAdapter
//{
//    public abstract class StorageManager : IPlatformAdapter
//    {
//        // TODO add support for serializing/deserializing credentials with encryption

//        public abstract void SaveLocal(string key, object obj);
//        public abstract T LoadLocal<T>(string key);

//        public virtual void SaveRoaming(string key, object obj)
//        {
//            this.SaveLocal(key, obj);
//        }
//        public virtual T LoadRoaming<T>(string key)
//        {
//            return this.LoadLocal<T>(key);
//        }

//        public abstract Uri GetFileUri(string path);

//        public abstract Task<string> LoadResourceFile(string path);
//        public async Task<T> LoadResourceFile<T>(string path, SerializerFileTypes fileType)
//        {
//            string data = await this.LoadFile(path);
//            return Serializer.Deserialize<T>(data, fileType);
//        }

//        public abstract Task<string> LoadFile(string path);
//        public async Task<T> LoadFile<T>(string path, SerializerFileTypes fileType)
//        {
//            string data = await this.LoadFile(path);
//            return Serializer.Deserialize<T>(data, fileType);
//        }

//        public abstract Task<Uri> SaveFile(string path, string data);
//        public Task<Uri> SaveFile<T>(string path, T data, SerializerFileTypes fileType)
//        {
//            return SaveFile(path, Serializer.Serialize(data, fileType));
//        }

//        public abstract void SaveCredential(string credentialName, string username, string password);

//        public abstract void LoadCredential(string credentialName, ref string username, ref string password);

//        public virtual void Initialize()
//        {
//        }

//        public virtual void Teardown()
//        {
//        }

//        protected string CleanPath(string path)
//        {
//            if (path == null)
//                return string.Empty;

//            path = path.Replace("ms-appx:///", "").Replace("isostore:/", "");

//            while (path.StartsWith("/"))
//                if (path.Length == 1)
//                    path = string.Empty;
//                else
//                    path = path.Substring(1);
//            return path.Trim();
//        }
//    }
//}
