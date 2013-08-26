using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace PlatformAdapter.Storage
{
    // Summary:
    //     Specifies whether an item that is deleted is sent to the Recycle Bin or permanently
    //     deleted.
    public enum StorageDeleteOption
    {
        // Summary:
        //     If the item is in an application storage location (a location that can be
        //     accessed through the ApplicationData class), it will be permanently deleted
        //     and won't appear in the Recycle Bin. Otherwise, the item is deleted according
        //     to the default behavior for the location (which may move the item to the
        //     Recycle Bin).
        Default = 0,
        //
        // Summary:
        //     Permanently deletes the item without moving it to the recycle bin.
        PermanentDelete = 1,
    }

    // Summary:
    //     Specifies what to do if a file or folder renamed, moved, or copied and there
    //     is an existing file or folder with the same name in the desired location.
    public enum NameCollisionOption
    {
        // Summary:
        //     Automatically generate a unique name by appending a number to the name of
        //     the file or folder.
        GenerateUniqueName = 0,
        //
        // Summary:
        //     Replace the existing file or folder. Your app must have permission to access
        //     the location that contains the existing file or folder.  Access to a location
        //     can be granted in several ways, for example, by a capability declared in
        //     your application's manifest, or by the user through the . You can use Windows.Storage.AccessCache
        //     to manage the list of locations that are accessible to your app via the .
        ReplaceExisting = 1,
        //
        // Summary:
        //     Return an error if another file or folder exists with the same name and abort
        //     the operation.
        FailIfExists = 2,
    }



    public interface IStorageItem
    {
        // Summary:
        //     Gets the attributes of a storage item.
        //
        // Returns:
        //     The file or folder attributes.
        FileAttributes Attributes { get; }
        //
        // Summary:
        //     Gets the date and time when the current item was created.
        //
        // Returns:
        //     The date and time when the current item was created.For example, in string
        //     format the DateTime that an item was created might be Fri Sep 16 13:47:08
        //     PDT 2011.
        DateTimeOffset DateCreated { get; }
        //
        // Summary:
        //     Gets the name of the item including the file name extension if there is one.
        //
        // Returns:
        //     The name of the item including the file name extension if there is one.
        string Name { get; }
        //
        // Summary:
        //     Gets the full file-system path of the item, if the item has a path.
        //
        // Returns:
        //     The full path of the item, if the item has a path in the user's file-system.
        string Path { get; }

        // Summary:
        //     Deletes the current item.
        //
        // Returns:
        //     No object or value is returned by this method when it completes.
        Task DeleteAsync();
        //
        // Summary:
        //     Deletes the current item, optionally deleting it permanently.
        //
        // Parameters:
        //   option:
        //     A value that indicates whether to delete the item permanently.
        //
        // Returns:
        //     No object or value is returned by this method when it completes.
        Task DeleteAsync(StorageDeleteOption option);
        //
        // Summary:
        //     Gets the basic properties of the current item (like a file or folder).
        //
        // Returns:
        //     When this method completes successfully, it returns the basic properties
        //     of the current item as a BasicProperties object.
        Task<IStorageItemExtraProperties> GetBasicPropertiesAsync();
        //
        // Summary:
        //     Determines whether the current IStorageItem matches the specified StorageItemTypes
        //     value.
        //
        // Parameters:
        //   type:
        //     The value to match against.
        //
        // Returns:
        //     True if the StorageFolder matches the specified value; otherwise false.
        bool IsOfType(StorageItemTypes type);
        //
        // Summary:
        //     Renames the current item.
        //
        // Parameters:
        //   desiredName:
        //     The desired, new name of the item.
        //
        // Returns:
        //     No object or value is returned by this method when it completes.
        Task RenameAsync(string desiredName);
        //
        // Summary:
        //     Renames the current item. This method also specifies what to do if an existing
        //     item in the current item's location has the same name.
        //
        // Parameters:
        //   desiredName:
        //     The desired, new name of the current item.If there is an existing item in
        //     the current item's location that already has the specified desiredName, the
        //     specified NameCollisionOption determines how responds to the conflict.
        //
        //   option:
        //     The enum value that determines how responds if the desiredName is the same
        //     as the name of an existing item in the current item's location.
        //
        // Returns:
        //     No object or value is returned by this method when it completes.
        Task RenameAsync(string desiredName, NameCollisionOption option);
    }

    // Summary:
    //     Saves and retrieves the properties of a storage item.
    public interface IStorageItemExtraProperties
    {
        // Summary:
        //     Retrieves the specified properties associated with the item.
        //
        // Parameters:
        //   propertiesToRetrieve:
        //     A collection that contains the names of the properties to retrieve.
        //
        // Returns:
        //     When this method completes successfully, it returns a collection (type IMap)
        //     that contains the specified properties and values as key-value pairs.
        Task<IDictionary<string, object>> RetrievePropertiesAsync(IEnumerable<string> propertiesToRetrieve);
        //
        // Summary:
        //     Saves all properties associated with the item.
        //
        // Returns:
        //     An object for managing the asynchronous save operation.
        Task SavePropertiesAsync();
        //
        // Summary:
        //     Saves the specified properties and values associated with the item.
        //
        // Parameters:
        //   propertiesToSave:
        //     A collection that contains the names and values of the properties to save
        //     as key-value pairs (type IKeyValuePair).
        //
        // Returns:
        //     No object or value is returned when this method completes.
        Task SavePropertiesAsync(IEnumerable<KeyValuePair<string, object>> propertiesToSave);
    }
}
