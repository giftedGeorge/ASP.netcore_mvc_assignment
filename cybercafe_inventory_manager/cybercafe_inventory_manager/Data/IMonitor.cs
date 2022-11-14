using cybercafe_inventory_manager.Models;
using System.Collections.Generic;

namespace cybercafe_inventory_manager.Data
{
    public interface IMonitor
    {
        bool SaveChanges();

        //get methods
        IEnumerable<Monitor> GetAllMonitors();
        Monitor GetMonitorById(int id);

        //post method
        void CreateMonitor(Monitor monitor);

        //Put method
        void UpdateMonitor(Monitor monitor);

        //Delete method
        void DeleteMonitor(Monitor monitor);
    }
}
