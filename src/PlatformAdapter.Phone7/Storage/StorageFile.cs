using PlatformAdapter.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter.Phone7.Storage
{
    public sealed class StorageFile : IStorageFile
    {
        private string path;
        private IsolatedStorageFile isoStorage;

        public StorageFile(string path)
        {
            this.isoStorage = System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication();
            if (!this.isoStorage.FileExists(path))
            {
                throw new System.IO.DirectoryNotFoundException();
            }

            this.path = PathConvert.ToPhonePath(path);
        }

        public PlatformAdapter.Storage.FileAttributes Attributes
        {
            get
            {
                return PlatformAdapter.Storage.FileAttributes.Normal;
            }
            //get 
            //{

            //    PlatformAdapter.Storage.FileAttributes attributes = 0;

            //    if ((System.IO.FileAttributes.Archive & this.fileInfo.Attributes) == System.IO.FileAttributes.Archive)
            //    {
            //        attributes |= PlatformAdapter.Storage.FileAttributes.Archive;
            //    }
            //    if ((System.IO.FileAttributes.Directory & this.fileInfo.Attributes) == System.IO.FileAttributes.Directory)
            //    {
            //        attributes |= PlatformAdapter.Storage.FileAttributes.Directory;
            //    }
            //    if ((System.IO.FileAttributes.ReadOnly & this.fileInfo.Attributes) == System.IO.FileAttributes.ReadOnly)
            //    {
            //        attributes |= PlatformAdapter.Storage.FileAttributes.ReadOnly;
            //    }
            //    if ((System.IO.FileAttributes.Temporary & this.fileInfo.Attributes) == System.IO.FileAttributes.Temporary)
            //    {
            //        attributes |= PlatformAdapter.Storage.FileAttributes.Temporary;
            //    }
            //    if ((System.IO.FileAttributes.Normal & this.fileInfo.Attributes) == System.IO.FileAttributes.Normal)
            //    {
            //        attributes |= PlatformAdapter.Storage.FileAttributes.Normal;
            //    }

            //    return attributes;
            //}
        }

        public DateTimeOffset DateCreated
        {
            get { return this.isoStorage.GetCreationTime(this.path); }
        }

        public string Name
        {
            get { return System.IO.Path.GetFileName(this.path); }
        }

        public string Path
        {
            get { return PathConvert.ToWinRtPath(this.path); }
        }

        public System.Threading.Tasks.Task DeleteAsync()
        {
            var tcs = new System.Threading.Tasks.TaskCompletionSource<object>();

            if (this.isoStorage.FileExists(this.path))
            {
                this.isoStorage.DeleteFile(this.path);
            }


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
            return (type == StorageItemTypes.File);
        }

        public System.Threading.Tasks.Task RenameAsync(string desiredName)
        {
            return this.RenameAsync(desiredName, NameCollisionOption.FailIfExists);
        }

        public System.Threading.Tasks.Task RenameAsync(string desiredName, NameCollisionOption option)
        {
            var tcs = new TaskCompletionSource<object>();

            string newPath = desiredName;

            switch (option)
            {
                case NameCollisionOption.GenerateUniqueName:
                    int i = 1;
                    while (this.isoStorage.FileExists(newPath))
                    {
                        newPath = desiredName + (++i).ToString();
                    }

                    break;
                case NameCollisionOption.ReplaceExisting:
                    if (this.isoStorage.FileExists(newPath))
                    {
                        this.isoStorage.DeleteFile(newPath);
                    }
                    break;
                case NameCollisionOption.FailIfExists:
                    if (this.isoStorage.FileExists(newPath))
                    {
                        throw new System.IO.IOException("Can't rename because target folder name already exists.");
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("option");

            }

            this.isoStorage.MoveFile(this.path, newPath);
            tcs.SetResult(null);

            return tcs.Task;
        }

        public string ContentType
        {
            get { throw new NotImplementedException(); }
        }

        public string FileType
        {
            get { throw new NotImplementedException(); }
        }

        public Task CopyAndReplaceAsync(IStorageFile fileToReplace)
        {
            var filePath = fileToReplace.Path;

            return fileToReplace.DeleteAsync().ContinueWith((t) => this.isoStorage.CopyFile(this.path, filePath));
        }

        public Task<IStorageFile> CopyAsync(IStorageFolder destinationFolder)
        {
            return this.CopyAsync(destinationFolder, this.Name, NameCollisionOption.FailIfExists);
        }

        public Task<IStorageFile> CopyAsync(IStorageFolder destinationFolder, string desiredNewName)
        {
            return this.CopyAsync(destinationFolder, desiredNewName, NameCollisionOption.FailIfExists);
        }

        public Task<IStorageFile> CopyAsync(IStorageFolder destinationFolder, string desiredNewName, NameCollisionOption option)
        {
            var tcs = new TaskCompletionSource<IStorageFile>();
            var filePath = System.IO.Path.Combine(destinationFolder.Path, desiredNewName);

            switch (option)
            {
                case NameCollisionOption.GenerateUniqueName:
                    var originalPath = filePath;
                    var i = 1;
                    while (this.isoStorage.FileExists(filePath))
                    {
                        filePath = originalPath + (++i).ToString();
                    }
                    break;
                case NameCollisionOption.ReplaceExisting:
                    if (this.isoStorage.FileExists(filePath))
                    {
                        this.isoStorage.DeleteFile(filePath);
                    }
                    break;
                case NameCollisionOption.FailIfExists:
                    if (this.isoStorage.FileExists(filePath))
                    {
                        throw new System.IO.IOException("File already exists");
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("option");
            }


            this.isoStorage.CopyFile(this.path, filePath);
            tcs.SetResult(new PlatformAdapter.Phone7.Storage.StorageFile(filePath));
            return tcs.Task;
        }

        public Task MoveAndReplaceAsync(IStorageFile fileToReplace)
        {
            var filePath = fileToReplace.Path;

            return fileToReplace.DeleteAsync().ContinueWith((t) => this.isoStorage.MoveFile(this.path, filePath));
        }

        public Task MoveAsync(IStorageFolder destinationFolder)
        {
            return this.MoveAsync(destinationFolder, this.Name, NameCollisionOption.FailIfExists);
        }

        public Task MoveAsync(IStorageFolder destinationFolder, string desiredNewName)
        {
            return this.MoveAsync(destinationFolder, desiredNewName, NameCollisionOption.FailIfExists);
        }

        public Task MoveAsync(IStorageFolder destinationFolder, string desiredNewName, NameCollisionOption option)
        {
            var tcs = new TaskCompletionSource<IStorageFile>();
            var filePath = System.IO.Path.Combine(destinationFolder.Path, desiredNewName);

            switch (option)
            {
                case NameCollisionOption.GenerateUniqueName:
                    var originalPath = filePath;
                    var i = 1;
                    while (this.isoStorage.FileExists(filePath))
                    {
                        filePath = originalPath + (++i).ToString();
                    }
                    break;
                case NameCollisionOption.ReplaceExisting:
                    if (this.isoStorage.FileExists(filePath))
                    {
                        this.isoStorage.DeleteFile(filePath);
                    }
                    break;
                case NameCollisionOption.FailIfExists:
                    if (this.isoStorage.FileExists(filePath))
                    {
                        throw new System.IO.IOException("File already exists");
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("option");
            }


            this.isoStorage.MoveFile(this.path, filePath);
            tcs.SetResult(new PlatformAdapter.Phone7.Storage.StorageFile(filePath));
            return tcs.Task;
        }
    }
}
