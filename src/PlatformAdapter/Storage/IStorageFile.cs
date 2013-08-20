using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter.Storage
{
    public interface IStorageFile : IStorageItem
    {
        // Summary:
        //     Gets the MIME type of the contents of the file.
        //
        // Returns:
        //     The type of the file contents.For example, a music file might have the audio/mpeg
        //     type.
        string ContentType { get; }
        //
        // Summary:
        //     Gets the type (file name extension) of the file.
        //
        // Returns:
        //     The file name extension of the file.
        string FileType { get; }

        // Summary:
        //     Replaces the specified file with a copy of the current file.
        //
        // Parameters:
        //   fileToReplace:
        //     The file to replace.
        //
        // Returns:
        //     No object or value is returned when this method completes.
        Task CopyAndReplaceAsync(IStorageFile fileToReplace);
        //
        // Summary:
        //     Creates a copy of the file in the specified folder.
        //
        // Parameters:
        //   destinationFolder:
        //     The destination folder where the copy is created.
        //
        // Returns:
        //     When this method completes, it returns a StorageFile that represents the
        //     copy.
        Task<IStorageFile> CopyAsync(IStorageFolder destinationFolder);
        //
        // Summary:
        //     Creates a copy of the file in the specified folder, using the desired name.
        //
        // Parameters:
        //   destinationFolder:
        //     The destination folder where the copy is created.
        //
        //   desiredNewName:
        //     The desired name of the copy.If there is an existing file in the destination
        //     folder that already has the specified desiredNewName, generates a unique
        //     name for the copy.
        //
        // Returns:
        //     When this method completes, it returns a StorageFile that represents the
        //     copy.
        Task<IStorageFile> CopyAsync(IStorageFolder destinationFolder, string desiredNewName);
        //
        // Summary:
        //     Creates a copy of the file in the specified folder, using the desired name.
        //     This method also specifies what to do if an existing file in the specified
        //     folder has the same name.
        //
        // Parameters:
        //   destinationFolder:
        //     The destination folder where the copy is created.
        //
        //   desiredNewName:
        //     The desired name of the copy.If there is an existing file in the destination
        //     folder that already has the specified desiredNewName, the specified NameCollisionOption
        //     determines how responds to the conflict.
        //
        //   option:
        //     An enum value that determines how responds if the desiredNewName is the same
        //     as the name of an existing file in the destination folder.
        //
        // Returns:
        //     When this method completes, it returns a StorageFile that represents the
        //     copy.
        Task<IStorageFile> CopyAsync(IStorageFolder destinationFolder, string desiredNewName, NameCollisionOption option);
        //
        // Summary:
        //     Moves the current file to the location of the specified file and replaces
        //     the specified file in that location.
        //
        // Parameters:
        //   fileToReplace:
        //     The file to replace.
        //
        // Returns:
        //     No object or value is returned by this method.
        Task MoveAndReplaceAsync(IStorageFile fileToReplace);
        //
        // Summary:
        //     Moves the current file to the specified folder.
        //
        // Parameters:
        //   destinationFolder:
        //     The destination folder where the file is moved.This destination folder must
        //     be a physical location. Otherwise, if the destination folder exists only
        //     in memory, like a file group, this method fails and throws an exception.
        //
        // Returns:
        //     No object or value is returned by this method.

        Task MoveAsync(IStorageFolder destinationFolder);
        //
        // Summary:
        //     Moves the current file to the specified folder and renames the file according
        //     to the desired name.
        //
        // Parameters:
        //   destinationFolder:
        //     The destination folder where the file is moved.This destination folder must
        //     be a physical location. Otherwise, if the destination folder exists only
        //     in memory, like a file group, this method fails and throws an exception.
        //
        //   desiredNewName:
        //     The desired name of the file after it is moved.If there is an existing file
        //     in the destination folder that already has the specified desiredNewName,
        //     generates a unique name for the file.
        //
        // Returns:
        //     No object or value is returned by this method.

        Task MoveAsync(IStorageFolder destinationFolder, string desiredNewName);
        //
        // Summary:
        //     Moves the current file to the specified folder and renames the file according
        //     to the desired name. This method also specifies what to do if a file with
        //     the same name already exists in the specified folder.
        //
        // Parameters:
        //   destinationFolder:
        //     The destination folder where the file is moved.This destination folder must
        //     be a physical location. Otherwise, if the destination folder exists only
        //     in memory, like a file group, this method fails and throws an exception.
        //
        //   desiredNewName:
        //     The desired name of the file after it is moved.If there is an existing file
        //     in the destination folder that already has the specified desiredNewName,
        //     the specified NameCollisionOption determines how responds to the conflict.
        //
        //   option:
        //     An enum value that determines how responds if the desiredNewName is the same
        //     as the name of an existing file in the destination folder.
        //
        // Returns:
        //     No object or value is returned by this method.
        
        Task MoveAsync(IStorageFolder destinationFolder, string desiredNewName, NameCollisionOption option);
        //
        // Summary:
        //     Opens a random-access stream over the file.
        //
        // Parameters:
        //   accessMode:
        //     The type of access to allow.
        //
        // Returns:
        //     When this method completes, it returns the random-access stream (type IRandomAccessStream).
        //Task<IRandomAccessStream> OpenAsync(FileAccessMode accessMode);
        
        //
        // Summary:
        //     Opens a transacted, random-access stream to the file.
        //
        // Returns:
        //     When this method completes, it returns a StorageStreamTransaction that contains
        //     the random-access stream and methods that can be used to complete transactions.
        //IAsyncOperation<StorageStreamTransaction> OpenTransactedWriteAsync();
    }
}
