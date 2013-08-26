using PlatformAdapter.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PlatformAdapter.WindowsStore.Storage
{
    public class StorageFile : IStorageFile
    {
        global::Windows.Storage.IStorageFile file;

        public StorageFile(global::Windows.Storage.IStorageFile file)
        {
            this.file = file;
        }

        public static implicit operator StorageFile(global::Windows.Storage.StorageFile file)
        {
            return new PlatformAdapter.WindowsStore.Storage.StorageFile(file);
        }

        public FileAttributes Attributes
        {
            get { return (FileAttributes) this.file.Attributes; }
        }

        public DateTimeOffset DateCreated
        {
            get { return this.file.DateCreated; }
        }

        public string Name
        {
            get { return this.file.Name; }
        }

        public string Path
        {
            get { return this.file.Path; }
        }

        public Task DeleteAsync()
        {
            return this.file.DeleteAsync().AsTask();
        }

        public Task DeleteAsync(PlatformAdapter.Storage.StorageDeleteOption option)
        {
            return this.file.DeleteAsync((global::Windows.Storage.StorageDeleteOption) option).AsTask();
        }

        public Task<PlatformAdapter.Storage.IStorageItemExtraProperties> GetBasicPropertiesAsync()
        {
            throw new NotImplementedException();
        }

        public bool IsOfType(PlatformAdapter.Storage.StorageItemTypes type)
        {
            return this.file.IsOfType((global::Windows.Storage.StorageItemTypes)type);
        }

        public Task RenameAsync(string desiredName)
        {
            return this.file.RenameAsync(desiredName).AsTask();
        }

        public Task RenameAsync(string desiredName, PlatformAdapter.Storage.NameCollisionOption option)
        {
            return this.file.RenameAsync(desiredName, (global::Windows.Storage.NameCollisionOption)option).AsTask();
        }

        public string ContentType
        {
            get { throw new NotImplementedException(); }
        }

        public string FileType
        {
            get { throw new NotImplementedException(); }
        }

        public Task CopyAndReplaceAsync(PlatformAdapter.Storage.IStorageFile fileToReplace)
        {
            throw new NotImplementedException();
        }

        public Task<PlatformAdapter.Storage.IStorageFile> CopyAsync(PlatformAdapter.Storage.IStorageFolder destinationFolder)
        {
            throw new NotImplementedException();
        }

        public Task<PlatformAdapter.Storage.IStorageFile> CopyAsync(PlatformAdapter.Storage.IStorageFolder destinationFolder, string desiredNewName)
        {
            throw new NotImplementedException();
        }

        public Task<PlatformAdapter.Storage.IStorageFile> CopyAsync(PlatformAdapter.Storage.IStorageFolder destinationFolder, string desiredNewName, PlatformAdapter.Storage.NameCollisionOption option)
        {
            throw new NotImplementedException();
        }

        public Task MoveAndReplaceAsync(PlatformAdapter.Storage.IStorageFile fileToReplace)
        {
            throw new NotImplementedException();
        }

        public Task MoveAsync(PlatformAdapter.Storage.IStorageFolder destinationFolder)
        {
            throw new NotImplementedException();
        }

        public Task MoveAsync(PlatformAdapter.Storage.IStorageFolder destinationFolder, string desiredNewName)
        {
            throw new NotImplementedException();
        }

        public Task MoveAsync(PlatformAdapter.Storage.IStorageFolder destinationFolder, string desiredNewName, PlatformAdapter.Storage.NameCollisionOption option)
        {
            throw new NotImplementedException();
        }
    }
}
