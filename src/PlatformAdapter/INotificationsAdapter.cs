using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter
{
    public interface INotificationsAdapter : IPlatformAdapter
    {
        void CreateOrUpdateTile(object model);
        void DeleteTile(object model);
        void ClearTile(object model);
        bool HasTile(object model);
        void ClearAllTiles();

        void DisplayToast(object model, object parameter = null);
    }
}