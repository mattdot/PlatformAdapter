using System;
using System.Threading.Tasks;

namespace PlatformAdapter.Device
{
	public partial class StorageAdapter
	{
		#region IStorageAdapter implementation
		public Task AppendLinesAsync (PlatformAdapter.Storage.IStorageFile file, System.Collections.Generic.IEnumerable<string> lines)
		{
			throw new NotImplementedException ();
		}
		public Task AppendLinesAsync (string path, System.Collections.Generic.IEnumerable<string> lines)
		{
			throw new NotImplementedException ();
		}
		public Task AppendTextAsync (PlatformAdapter.Storage.IStorageFile file, string text)
		{
			throw new NotImplementedException ();
		}
		public Task AppendTextAsync (string path, string text)
		{
			throw new NotImplementedException ();
		}
		public Task<string> ReadTextAsync (PlatformAdapter.Storage.IStorageFile file)
		{
			throw new NotImplementedException ();
		}
		public Task<string> ReadTextAsync (string path)
		{
			throw new NotImplementedException ();
		}
		public Task<byte[]> ReadBytesAsync (PlatformAdapter.Storage.IStorageFile file)
		{
			throw new NotImplementedException ();
		}
		public Task<byte[]> ReadBytesAsync (string path)
		{
			throw new NotImplementedException ();
		}
		public Task WriteBytesAsync (string path, byte[] bytes)
		{
			throw new NotImplementedException ();
		}
		public Task WriteBytesAsync (PlatformAdapter.Storage.IStorageFile file, byte[] bytes)
		{
			throw new NotImplementedException ();
		}
		public Task WriteTextAsync (string path, string text)
		{
			throw new NotImplementedException ();
		}
		public Task WriteTextAsync (PlatformAdapter.Storage.IStorageFile file, string text)
		{
			throw new NotImplementedException ();
		}
		public Task WriteLinesAsync (string path, System.Collections.Generic.IEnumerable<string> lines)
		{
			throw new NotImplementedException ();
		}
		public Task WriteLinesAsync (PlatformAdapter.Storage.IStorageFile file, System.Collections.Generic.IEnumerable<string> lines)
		{
			throw new NotImplementedException ();
		}
		public PlatformAdapter.Storage.IStorageFolder LocalFolder {
			get {
				throw new NotImplementedException ();
			}
		}
		public PlatformAdapter.Storage.IStorageFolder RoamingFolder {
			get {
				throw new NotImplementedException ();
			}
		}
		public bool SupportsRoaming {
			get {
				throw new NotImplementedException ();
			}
		}
		#endregion
		#region IDisposable implementation
		public void Dispose ()
		{
			throw new NotImplementedException ();
		}
		#endregion
	}
}

