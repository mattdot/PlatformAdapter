using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter.Storage
{
    public interface IStorageFolder : IStorageItem
    {
        // Summary:
        //     Creates a new file in the current folder.
        //
        // Parameters:
        //   desiredName:
        //     The desired name of the file to create.
        //
        // Returns:
        //     When this method completes, it returns the new file as a StorageFile.
        Task<IStorageFile> CreateFileAsync(string desiredName);
        //
        // Summary:
        //     Creates a new file in the current folder, and specifies what to do if a file
        //     with the same name already exists in the current folder.
        //
        // Parameters:
        //   desiredName:
        //     The desired name of the file to create.If there is an existing file in the
        //     current folder that already has the specified desiredName, the specified
        //     CreationCollisionOption determines how responds to the conflict.
        //
        //   options:
        //     The enum value that determines how responds if the desiredName is the same
        //     as the name of an existing file in the current folder.
        //
        // Returns:
        //     When this method completes, it returns the new file as a StorageFile.

        Task<IStorageFile> CreateFileAsync(string desiredName, CreationCollisionOption options);
        //
        // Summary:
        //     Creates a new folder in the current folder.
        //
        // Parameters:
        //   desiredName:
        //     The desired name of the folder to create.
        //
        // Returns:
        //     When this method completes, it returns the new folder as a StorageFolder.
        Task<IStorageFolder> CreateFolderAsync(string desiredName);
        //
        // Summary:
        //     Creates a new folder in the current folder, and specifies what to do if a
        //     folder with the same name already exists in the current folder.
        //
        // Parameters:
        //   desiredName:
        //     The desired name of the folder to create.If there is an existing folder in
        //     the current folder that already has the specified desiredName, the specified
        //     CreationCollisionOption determines how responds to the conflict.
        //
        //   options:
        //     The enum value that determines how responds if the desiredName is the same
        //     as the name of an existing folder in the current folder.
        //
        // Returns:
        //     When this method completes, it returns the new folder as a StorageFolder.

        Task<IStorageFolder> CreateFolderAsync(string desiredName, CreationCollisionOption options);
        //
        // Summary:
        //     Gets the specified file from the current folder.
        //
        // Parameters:
        //   name:
        //     The name (or path relative to the current folder) of the file to retrieve.
        //
        // Returns:
        //     When this method completes successfully, it returns a StorageFile that represents
        //     the file.
        Task<IStorageFile> GetFileAsync(string name);
        //
        // Summary:
        //     Gets the files from the current folder.
        //
        // Returns:
        //     When this method completes successfully, it returns a list of the files (type
        //     IVectorView) in the folder. Each file in the list is represented by a StorageFile
        //     object.
        Task<System.Collections.Generic.IList<IStorageFile>> GetFilesAsync();
        //
        // Summary:
        //     Gets the specified folder from the current folder.
        //
        // Parameters:
        //   name:
        //     The name of the child folder to retrieve.
        //
        // Returns:
        //     When this method completes successfully, it returns a StorageFolder that
        //     represents the child folder.
        Task<IStorageFolder> GetFolderAsync(string name);
        //
        // Summary:
        //     Gets the folders in the current folder.
        //
        // Returns:
        //     When this method completes successfully, it returns a list of the files (type
        //     IVectorView). Each folder in the list is represented by a StorageFolder.
        Task<IList<IStorageFolder>> GetFoldersAsync();
        //
        // Summary:
        //     Gets the specified item from the IStorageFolder.
        //
        // Parameters:
        //   name:
        //     The name of the item to retrieve.
        //
        // Returns:
        //     When this method completes successfully, it returns the file or folder (type
        //     IStorageItem).
        Task<IStorageItem> GetItemAsync(string name);
        //
        // Summary:
        //     Gets the items from the current folder.
        //
        // Returns:
        //     When this method completes successfully, it returns a list of the files and
        //     folders (type IVectorView). The files and folders in the list are represented
        //     by objects of type IStorageItem.
        Task<IList<IStorageItem>> GetItemsAsync();
    }

    // Summary:
    //     Specifies what to do if a file with the desired name already exists in the
    //     current folder.
    public enum CreationCollisionOption
    {
        // Summary:
        //     Create the new file or folder with the desired name, or automatically appends
        //     a number if a file or folder already exists with that name.
        GenerateUniqueName = 0,
        //
        // Summary:
        //     Create the new file or folder with the desired name, and replaces any file
        //     or folder that already exists with that name.
        ReplaceExisting = 1,
        //
        // Summary:
        //     Create the new file or folder with the desired name, or returns an error
        //     if a file or folder already exists with that name.
        FailIfExists = 2,
        //
        // Summary:
        //     Create the new file or folder with the desired name, or returns an existing
        //     item if a file or folder already exists with that name.
        OpenIfExists = 3,
    }
}
