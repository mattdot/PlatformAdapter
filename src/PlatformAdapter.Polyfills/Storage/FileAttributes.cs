using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

#if WP8 || WINDOWS
[assembly: TypeForwardedTo(typeof(Windows.Storage.FileAttributes))]
#else
namespace Windows.Storage
{
    // Summary:
    //     Describes the attributes of system file or folder.
    [Flags]
    public enum FileAttributes
    {
        // Summary:
        //     The item is normal.
        Normal = 0,
        //
        // Summary:
        //     The item is read only.
        ReadOnly = 1,
        //
        // Summary:
        //     The item is a directory.
        Directory = 16,
        //
        // Summary:
        //     The item is archived.
        Archive = 32,
        //
        // Summary:
        //     The item is a temporary file.
        Temporary = 256,
    }
}
#endif