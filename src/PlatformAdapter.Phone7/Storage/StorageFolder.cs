using PlatformAdapter.Storage;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace PlatformAdapter.Phone7.Storage
{
    public class IsolatedStorageFolder : IStorageFolder
    {
        IsolatedStorageFile isoStorage;
        string path;

        public IsolatedStorageFolder(string path)
        {
            this.isoStorage = System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication();
            if (!this.isoStorage.DirectoryExists(path))
            {
                throw new System.IO.DirectoryNotFoundException();
            }

            this.path = path;
        }

        public FileAttributes Attributes
        {
            get { return FileAttributes.Directory; }
        }

        public DateTimeOffset DateCreated
        {
            get { return this.isoStorage.GetCreationTime(this.path); }
        }

        public string Name
        {
            get { return System.IO.Path.GetDirectoryName(this.path); }
        }

        public string Path
        {
            get { return this.path; }
        }

        public System.Threading.Tasks.Task DeleteAsync()
        {
            var tcs = new TaskCompletionSource<object>();
            this.isoStorage.DeleteDirectory(this.path);
            tcs.SetResult(null);
            return tcs.Task;
        }

        public System.Threading.Tasks.Task DeleteAsync(StorageDeleteOption option)
        {
            return this.DeleteAsync();
        }

        public System.Threading.Tasks.Task<IStorageItemExtraProperties> GetBasicPropertiesAsync()
        {
            throw new NotImplementedException();
        }

        public bool IsOfType(StorageItemTypes type)
        {
            return StorageItemTypes.Folder == type;
        }

        public System.Threading.Tasks.Task RenameAsync(string desiredName)
        {
            var tcs = new TaskCompletionSource<object>();
            this.isoStorage.MoveDirectory(this.path, desiredName);
            this.path = desiredName;

            tcs.SetResult(null);
            return tcs.Task;
        }

        public System.Threading.Tasks.Task RenameAsync(string desiredName, NameCollisionOption option)
        {
            var tcs = new TaskCompletionSource<object>();

            string newPath = desiredName;

            switch (option)
            {
                case NameCollisionOption.GenerateUniqueName:
                    int i = 1;
                    while (this.isoStorage.DirectoryExists(newPath))
                    {
                        newPath = desiredName + (++i).ToString();
                    }

                    break;
                case NameCollisionOption.ReplaceExisting:
                    if (this.isoStorage.DirectoryExists(newPath))
                    {
                        this.isoStorage.DeleteDirectory(newPath);
                    }
                    break;
                case NameCollisionOption.FailIfExists:
                    if (this.isoStorage.DirectoryExists(newPath))
                    {
                        throw new System.IO.IOException("Can't rename because target folder name already exists.");
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("option");
                    
            }

            this.isoStorage.MoveDirectory(this.path, newPath);
            tcs.SetResult(null);

            return tcs.Task;
        }

        public Task<IStorageFile> CreateFileAsync(string desiredName)
        {
            return this.CreateFileAsync(desiredName, CreationCollisionOption.FailIfExists);
        }

        public Task<IStorageFile> CreateFileAsync(string desiredName, CreationCollisionOption options)
        {
            var tcs = new TaskCompletionSource<IStorageFile>();
            var filePath = System.IO.Path.Combine(this.path, desiredName);

            switch (options)
            {
                case CreationCollisionOption.GenerateUniqueName:
                    int i = 1;
                    var originalFilePath = filePath;
                    while (this.isoStorage.FileExists(filePath))
                    {
                        filePath = originalFilePath + (++i).ToString();
                    }
                    break;
                case CreationCollisionOption.ReplaceExisting:

                    if (this.isoStorage.FileExists(filePath))
                    {
                        this.isoStorage.DeleteFile(filePath);
                    }
                    break;
                case CreationCollisionOption.FailIfExists:
                    if (this.isoStorage.FileExists(filePath))
                    {
                        throw new System.IO.IOException("File already exists");
                    }
                    break;
                case CreationCollisionOption.OpenIfExists:
                    if (this.isoStorage.FileExists(filePath))
                    {
                        tcs.SetResult(new PlatformAdapter.Phone7.Storage.StorageFile(filePath));
                        return tcs.Task;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("options");
            }

            using (var fs = this.isoStorage.CreateFile(filePath))
            {
                //do nothing;
            }
            tcs.SetResult(new PlatformAdapter.Phone7.Storage.StorageFile(filePath));

            return tcs.Task;
        }

        public Task<IStorageFolder> CreateFolderAsync(string desiredName)
        {
            return this.CreateFolderAsync(desiredName, CreationCollisionOption.OpenIfExists);
        }

        public Task<IStorageFolder> CreateFolderAsync(string desiredName, CreationCollisionOption options)
        {
            var tcs = new TaskCompletionSource<IStorageFolder>();
            var folderPath = System.IO.Path.Combine(this.path, desiredName);

            switch (options)
            {
                case CreationCollisionOption.GenerateUniqueName:
                    int i = 1;
                    while (this.isoStorage.DirectoryExists(folderPath))
                    {
                        folderPath = System.IO.Path.Combine(this.path, desiredName + (++i).ToString());
                    }

                    break;
                case CreationCollisionOption.ReplaceExisting:
                    if (this.isoStorage.DirectoryExists(folderPath))
                    {
                        this.isoStorage.DeleteDirectory(folderPath);
                    }
                    break;
                case CreationCollisionOption.FailIfExists:
                    if (this.isoStorage.DirectoryExists(folderPath))
                    {
                        throw new System.IO.IOException("Folder already exists");
                    }
                    break;
                case CreationCollisionOption.OpenIfExists:
                    if (this.isoStorage.DirectoryExists(folderPath))
                    {
                        tcs.SetResult(new PlatformAdapter.Phone7.Storage.IsolatedStorageFolder(folderPath));
                        return tcs.Task;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("options");
            }

            this.isoStorage.CreateDirectory(folderPath);
            tcs.SetResult(new PlatformAdapter.Phone7.Storage.IsolatedStorageFolder(folderPath));

            return tcs.Task;
        }

        public Task<IStorageFile> GetFileAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IList<IStorageFile>> GetFilesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IStorageFolder> GetFolderAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IList<IStorageFolder>> GetFoldersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IStorageItem> GetItemAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IList<IStorageItem>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
