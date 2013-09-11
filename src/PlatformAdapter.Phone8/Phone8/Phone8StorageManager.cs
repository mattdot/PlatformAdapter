//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.IO.IsolatedStorage;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PlatformAdapter.Phone8
//{
//    internal sealed class Phone8StorageManager : StorageManager
//    {
//        public override void SaveLocal(string key, object obj)
//        {
//            if (string.IsNullOrWhiteSpace(key))
//                throw new ArgumentNullException("key");

//            if (obj == null)
//                IsolatedStorageSettings.ApplicationSettings.Remove(key);
//            else if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
//                IsolatedStorageSettings.ApplicationSettings[key] = obj;
//            else
//                IsolatedStorageSettings.ApplicationSettings.Add(key, obj);

//            IsolatedStorageSettings.ApplicationSettings.Save();
//        }

//        public override T LoadLocal<T>(string key)
//        {
//            if (string.IsNullOrWhiteSpace(key))
//                throw new ArgumentNullException("key");

//            try
//            {
//                if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
//                    return (T)IsolatedStorageSettings.ApplicationSettings[key];
//                else
//                    return default(T);
//            }
//            catch (Exception ex)
//            {
//                //TODO LogHelper.Error(string.Format("Could not load key '{0}' from Storage", key), ex);
//                throw ex;
//            }
//        }

//        public override Task<string> LoadResourceFile(string path)
//        {
//            path = CleanPath(path);
//            if (string.IsNullOrWhiteSpace(path))
//                throw new ArgumentException("Path cannot be null or blank", "path");

//            var tcs = new TaskCompletionSource<string>();

//            System.Windows.Resources.StreamResourceInfo sri = null;
//            Uri uri = this.GetFileUri(path);
//            try
//            {
//                sri = System.Windows.Application.GetResourceStream(uri);
//                if (sri == null)
//                    tcs.SetResult(null);
//                else
//                {
//                    using (StreamReader sr = new StreamReader(sri.Stream))
//                    {
//                        tcs.SetResult(sr.ReadToEnd());
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                string msg = string.Format("Error loading resource file {0}", uri.ToString());
//                tcs.SetException(new Exception(msg, ex));
//            }
//            finally
//            {
//                if (sri != null)
//                    sri.Stream.Close();
//            }

//            return tcs.Task;
//        }

//        public override Task<string> LoadFile(string path)
//        {
//            path = CleanPath(path);
//            if (string.IsNullOrWhiteSpace(path))
//                throw new ArgumentException("Path cannot be null or blank", "path");

//            var tcs = new TaskCompletionSource<string>();
//            try
//            {
//                using (IsolatedStorageFile local = IsolatedStorageFile.GetUserStoreForApplication())
//                {
//                    using (var stream = new IsolatedStorageFileStream(path, System.IO.FileMode.Open, local))
//                    {
//                        using (var isoFileReader = new System.IO.StreamReader(stream))
//                        {
//                            tcs.SetResult(isoFileReader.ReadLine());
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                tcs.SetException(ex);
//            }

//            return tcs.Task;
//        }

//        public override Task<Uri> SaveFile(string path, string data)
//        {
//            path = CleanPath(path);
//            if (string.IsNullOrWhiteSpace(path))
//                throw new ArgumentException("Path cannot be null or blank", "path");

//            var tcs = new TaskCompletionSource<Uri>();
//            try
//            {
//                using (IsolatedStorageFile local = IsolatedStorageFile.GetUserStoreForApplication())
//                {
//                    using (var isoFileStream = new IsolatedStorageFileStream(path, System.IO.FileMode.OpenOrCreate, local))
//                    {
//                        // Write the data from the textbox.
//                        using (var isoFileWriter = new System.IO.StreamWriter(isoFileStream))
//                        {
//                            isoFileWriter.WriteLine(data);
//                        }
//                    }
//                }

//                tcs.SetResult(GetFileUri(path));
//            }
//            catch (Exception ex)
//            {
//                tcs.SetException(ex);
//            }

//            return tcs.Task;
//        }

//        public override Uri GetFileUri(string path)
//        {
//            path = CleanPath(path);
//            if (string.IsNullOrWhiteSpace(path))
//                throw new ArgumentException("Path cannot be null or blank", "path");

//            return new Uri(@"isostore:\" + path, UriKind.Absolute);
//        }

//        public override void SaveCredential(string credentialName, string username, string password)
//        {
//            this.SaveRoaming("Key1-" + credentialName, Platform.Cryptography.Encrypt(credentialName, username));
//            this.SaveRoaming("Key2-" + credentialName, Platform.Cryptography.Encrypt(credentialName, password));
//        }

//        public override void LoadCredential(string credentialName, ref string username, ref string password)
//        {
//            username = Platform.Cryptography.Decrypt(credentialName, this.LoadRoaming<string>("Key1-" + credentialName));
//            password = Platform.Cryptography.Decrypt(credentialName, this.LoadRoaming<string>("Key2-" + credentialName));
//        }
//    }
//}
