using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter
{
    public enum DialogResults
    {
        Ok,
        Cancel,
        Yes,
        No,
        None,
        Allow,
        Custom
    }
    public enum DialogTypes
    {
        Ok,
        OkCancel,
        YesNo,
        YesNoCancel,
        AllowCancel
    }

    public interface IDialogAdapter : IPlatformAdapter
    {
        Task<DialogResults> ShowMessageBox(DialogTypes type, string message, string title = null);
        Task<string> ShowMessageBox(string message, string title, params string[] buttonNames);
    }
}
