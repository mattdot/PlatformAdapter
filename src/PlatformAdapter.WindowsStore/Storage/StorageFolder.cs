using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace PlatformAdapter.WindowsStore.Storage
{
    public class StorageFolder : PlatformAdapter.Storage.IStorageFolder
    {
        private global::Windows.Storage.IStorageFolder storageFolder;

        public StorageFolder(global::Windows.Storage.IStorageFolder folder)
        {
            this.storageFolder = folder;
        }

        public FileAttributes Attributes
        {
            get { return (FileAttributes)this.storageFolder.Attributes; }
        }

        public DateTimeOffset DateCreated
        {
            get { return this.storageFolder.DateCreated; }
        }

        public string Name
        {
            get { return this.storageFolder.Name; }
        }

        public string Path
        {
            get { return this.storageFolder.Path; }
        }

        public Task DeleteAsync()
        {
            return this.storageFolder.DeleteAsync().AsTask();
        }

        public Task DeleteAsync(PlatformAdapter.Storage.StorageDeleteOption option)
        {
            return this.storageFolder.DeleteAsync((global::Windows.Storage.StorageDeleteOption)option).AsTask();
        }

        public Task<PlatformAdapter.Storage.IStorageItemExtraProperties> GetBasicPropertiesAsync()
        {
            throw new NotImplementedException();
        }

        public bool IsOfType(PlatformAdapter.Storage.StorageItemTypes type)
        {
            return this.storageFolder.IsOfType((global::Windows.Storage.StorageItemTypes)type);
        }

        public Task RenameAsync(string desiredName)
        {
            return this.storageFolder.RenameAsync(desiredName).AsTask();
        }

        public Task RenameAsync(string desiredName, PlatformAdapter.Storage.NameCollisionOption option)
        {
            return this.storageFolder.RenameAsync(desiredName, (global::Windows.Storage.NameCollisionOption)option).AsTask();
        }

        public Task<PlatformAdapter.Storage.IStorageFile> CreateFileAsync(string desiredName)
        {
            return this.storageFolder.CreateFileAsync(desiredName).AsTask()
                .ContinueWith<PlatformAdapter.Storage.IStorageFile>(x => new PlatformAdapter.WindowsStore.Storage.StorageFile(x.Result));
        }

        public Task<PlatformAdapter.Storage.IStorageFile> CreateFileAsync(string desiredName, PlatformAdapter.Storage.CreationCollisionOption options)
        {
            return this.storageFolder.CreateFileAsync(desiredName, (global::Windows.Storage.CreationCollisionOption) options).AsTask()
                .ContinueWith<PlatformAdapter.Storage.IStorageFile>(x => new PlatformAdapter.WindowsStore.Storage.StorageFile(x.Result));
        }

        public Task<PlatformAdapter.Storage.IStorageFolder> CreateFolderAsync(string desiredName)
        {
            return this.storageFolder.CreateFolderAsync(desiredName).AsTask()
                .ContinueWith<PlatformAdapter.Storage.IStorageFolder>(x => new PlatformAdapter.WindowsStore.Storage.StorageFolder(x.Result));
        }

        public Task<PlatformAdapter.Storage.IStorageFolder> CreateFolderAsync(string desiredName, PlatformAdapter.Storage.CreationCollisionOption options)
        {
            return this.storageFolder.CreateFolderAsync(desiredName, (global::Windows.Storage.CreationCollisionOption)options).AsTask()
                .ContinueWith<PlatformAdapter.Storage.IStorageFolder>(x => new PlatformAdapter.WindowsStore.Storage.StorageFolder(x.Result));
        }

        public Task<PlatformAdapter.Storage.IStorageFile> GetFileAsync(string name)
        {
            return this.storageFolder.GetFileAsync(name).AsTask()
                .ContinueWith<PlatformAdapter.Storage.IStorageFile>(x => new PlatformAdapter.WindowsStore.Storage.StorageFile(x.Result));
        }

        public Task<IList<PlatformAdapter.Storage.IStorageFile>> GetFilesAsync()
        {
            return this.storageFolder.GetFilesAsync().AsTask()
                .ContinueWith<IList<PlatformAdapter.Storage.IStorageFile>>(x => x.Result.Select(y => new PlatformAdapter.WindowsStore.Storage.StorageFile(y)).ToList<PlatformAdapter.Storage.IStorageFile>());
        }

        public Task<PlatformAdapter.Storage.IStorageFolder> GetFolderAsync(string name)
        {
            return this.storageFolder.GetFolderAsync(name).AsTask()
                .ContinueWith<PlatformAdapter.Storage.IStorageFolder>((x) => new PlatformAdapter.WindowsStore.Storage.StorageFolder(x.Result));
        }

        public Task<IList<PlatformAdapter.Storage.IStorageFolder>> GetFoldersAsync()
        {
            return this.storageFolder.GetFoldersAsync().AsTask()
                .ContinueWith<IList<PlatformAdapter.Storage.IStorageFolder>>(x => x.Result.Select(y => new PlatformAdapter.WindowsStore.Storage.StorageFolder(y)).ToList<PlatformAdapter.Storage.IStorageFolder>());
        }

        public Task<PlatformAdapter.Storage.IStorageItem> GetItemAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IList<PlatformAdapter.Storage.IStorageItem>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
