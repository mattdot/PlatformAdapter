using PlatformAdapter.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter
{
    public interface IStorageAdapter : IPlatformAdapter
    {
        IStorageFolder LocalFolder { get; }
        IStorageFolder RoamingFolder { get; }

        bool SupportsRoaming { get; }

        Task AppendLinesAsync(IStorageFile file, IEnumerable<string> lines);
        Task AppendLinesAsync(string path, IEnumerable<string> lines);

        Task AppendTextAsync(IStorageFile file, string text);
        Task AppendTextAsync(string path, string text);

        Task<string> ReadTextAsync(IStorageFile file);
        Task<string> ReadTextAsync(string path);

        Task<byte[]> ReadBytesAsync(IStorageFile file);
        Task<byte[]> ReadBytesAsync(string path);

        Task WriteBytesAsync(string path, byte[] bytes);
        Task WriteBytesAsync(IStorageFile file, byte[] bytes);

        Task WriteTextAsync(string path, string text);
        Task WriteTextAsync(IStorageFile file, string text);

        Task WriteLinesAsync(string path, IEnumerable<string> lines);
        Task WriteLinesAsync(IStorageFile file, IEnumerable<string> lines);
    }
}
