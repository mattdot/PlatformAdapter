using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.Runtime.InteropServices.WindowsRuntime;

namespace PlatformAdapter.WindowsStore
{
    internal class StorageAdapter : IStorageAdapter
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

        public Task AppendLinesAsync(PlatformAdapter.Storage.IStorageFile file, IEnumerable<string> lines)
        {
            return PathIO.AppendLinesAsync(file.Path, lines).AsTask();
        }

        public Task AppendTextAsync(PlatformAdapter.Storage.IStorageFile file, string text)
        {
            return PathIO.AppendTextAsync(file.Path, text).AsTask();
        }

        public Task<string> ReadTextAsync(PlatformAdapter.Storage.IStorageFile file)
        {
            return PathIO.ReadTextAsync(file.Path).AsTask();
        }

        public Task<byte[]> ReadBytesAsync(PlatformAdapter.Storage.IStorageFile file)
        {
            return PathIO.ReadBufferAsync(file.Path).AsTask().ContinueWith(x => x.Result.ToArray());
        }

        public Task WriteBytesAsync(PlatformAdapter.Storage.IStorageFile file, byte[] bytes)
        {
            return PathIO.WriteBytesAsync(file.Path, bytes).AsTask();
        }

        public Task WriteTextAsync(PlatformAdapter.Storage.IStorageFile file, string text)
        {
            return PathIO.WriteTextAsync(file.Path, text).AsTask();
        }

        public Task WriteLinesAsync(PlatformAdapter.Storage.IStorageFile file, IEnumerable<string> lines)
        {
            return PathIO.WriteLinesAsync(file.Path, lines).AsTask();
        }


        public bool SupportsRoaming
        {
            get { return true; }
        }

        public Task AppendLinesAsync(string path, IEnumerable<string> lines)
        {
            return PathIO.AppendLinesAsync(path, lines).AsTask();
        }

        public Task AppendTextAsync(string path, string text)
        {
            return PathIO.AppendTextAsync(path, text).AsTask();
        }

        public Task<string> ReadTextAsync(string path)
        {
            return PathIO.ReadTextAsync(path).AsTask();
        }

        public Task<byte[]> ReadBytesAsync(string path)
        {
            return PathIO.ReadBufferAsync(path).AsTask().ContinueWith<byte[]>(x => x.Result.ToArray());
        }

        public Task WriteBytesAsync(string path, byte[] bytes)
        {
            return PathIO.WriteBytesAsync(path, bytes).AsTask();
        }

        public Task WriteTextAsync(string path, string text)
        {
            return PathIO.WriteTextAsync(path, text).AsTask();
        }

        public Task WriteLinesAsync(string path, IEnumerable<string> lines)
        {
            return PathIO.WriteLinesAsync(path, lines).AsTask();
        }
    }
}
