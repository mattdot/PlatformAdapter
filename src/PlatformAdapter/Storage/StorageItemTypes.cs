using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter.Storage
{
    // Summary:
    //     Describes the kind of item that is represented by an instance of a class
    //     that implements IStorageItem (like a StorageFile or StorageFolder object).
    [Flags]
    public enum StorageItemTypes
    {
        // Summary:
        //     A generic storage item that represents either a file or a folder.
        None = 0,
        //
        // Summary:
        //     A file that is represented as a StorageFile instance.
        File = 1,
        //
        // Summary:
        //     A folder that is represented as a StorageFolder instance.
        Folder = 2,
    }
}
