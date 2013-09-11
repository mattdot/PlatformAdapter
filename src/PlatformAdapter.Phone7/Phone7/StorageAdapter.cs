using PlatformAdapter.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter.Phone7
{
    public sealed class StorageAdapter : IStorageAdapter
    {
        IsolatedStorageFile iso;

        public StorageAdapter()
        {
            this.iso = IsolatedStorageFile.GetUserStoreForApplication();
        }

        public StorageAdapter(IsolatedStorageFile file)
        {
            this.iso = file;
        }

        public IStorageFolder LocalFolder
        {
            get { throw new NotImplementedException(); }
        }

        public IStorageFolder RoamingFolder
        {
            get { throw new NotImplementedException(); }
        }

        public bool SupportsRoaming
        {
            get { throw new NotImplementedException(); }
        }

        public Task AppendLinesAsync(IStorageFile file, IEnumerable<string> lines)
        {
            throw new NotImplementedException();
        }

        public Task AppendLinesAsync(string path, IEnumerable<string> lines)
        {
            throw new NotImplementedException();
        }

        public Task AppendTextAsync(IStorageFile file, string text)
        {
            throw new NotImplementedException();
        }

        public Task AppendTextAsync(string path, string text)
        {
            throw new NotImplementedException();
        }

        public Task<string> ReadTextAsync(IStorageFile file)
        {
            throw new NotImplementedException();
        }

        public Task<string> ReadTextAsync(string path)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> ReadBytesAsync(IStorageFile file)
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

        public Task WriteBytesAsync(IStorageFile file, byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public Task WriteTextAsync(string path, string text)
        {
            throw new NotImplementedException();
        }

        public Task WriteTextAsync(IStorageFile file, string text)
        {
            throw new NotImplementedException();
        }

        public Task WriteLinesAsync(string path, IEnumerable<string> lines)
        {
            throw new NotImplementedException();
        }

        public Task WriteLinesAsync(IStorageFile file, IEnumerable<string> lines)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (null != this.iso)
            {
                this.iso.Dispose();
                this.iso = null;
            }

            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        ~StorageAdapter()
        {
            Dispose(false);
        }
    }
}