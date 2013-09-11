using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter.Phone8
{
    public sealed class StorageAdapter : IStorageAdapter
    {
        Lazy<PlatformAdapter.Storage.IStorageFolder> localFolder = new Lazy<PlatformAdapter.Storage.IStorageFolder>(() => new PlatformAdapter.WindowsStore.Storage.StorageFolder(global::Windows.Storage.ApplicationData.Current.LocalFolder));
        Lazy<PlatformAdapter.Storage.IStorageFolder> roamingFolder = new Lazy<PlatformAdapter.Storage.IStorageFolder>(() => new PlatformAdapter.WindowsStore.Storage.StorageFolder(global::Windows.Storage.ApplicationData.Current.RoamingFolder));

        public PlatformAdapter.Storage.IStorageFolder LocalFolder
        {
            get { return this.localFolder.Value; }
        }

        public PlatformAdapter.Storage.IStorageFolder RoamingFolder
        {
            get { return this.roamingFolder.Value; }
        }

        public bool SupportsRoaming
        {
            get { return false; }
        }

        public async Task AppendLinesAsync(Storage.IStorageFile file, IEnumerable<string> lines)
        {
            
        }

        public Task AppendLinesAsync(string path, IEnumerable<string> lines)
        {
            throw new NotImplementedException();
        }

        public Task AppendTextAsync(Storage.IStorageFile file, string text)
        {
            throw new NotImplementedException();
        }

        public Task AppendTextAsync(string path, string text)
        {
            throw new NotImplementedException();
        }

        public Task<string> ReadTextAsync(Storage.IStorageFile file)
        {
            throw new NotImplementedException();
        }

        public Task<string> ReadTextAsync(string path)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> ReadBytesAsync(Storage.IStorageFile file)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> ReadBytesAsync(string path)
        {
            throw new NotImplementedException();
        }

        public Task WriteBytesAsync(string path, byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public Task WriteBytesAsync(Storage.IStorageFile file, byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public Task WriteTextAsync(string path, string text)
        {
            throw new NotImplementedException();
        }

        public Task WriteTextAsync(Storage.IStorageFile file, string text)
        {
            throw new NotImplementedException();
        }

        public Task WriteLinesAsync(string path, IEnumerable<string> lines)
        {
            throw new NotImplementedException();
        }

        public Task WriteLinesAsync(Storage.IStorageFile file, IEnumerable<string> lines)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
