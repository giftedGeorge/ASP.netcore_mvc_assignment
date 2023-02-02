using cybercafe_inventory_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cybercafe_inventory_manager.Data
{
    public class MonitorInventoryRepo : IMonitorRepository
    {
        private readonly CafeInventoryContext _context;

        public MonitorInventoryRepo(CafeInventoryContext context)
        {
            _context = context;
        }

        public void CreateMonitor(Monitor monitor)
        {
            if (monitor == null)
            {
                throw new ArgumentNullException(nameof(monitor));
            }
            _context.Monitors.Add(monitor);
        }

        public void DeleteMonitor(Monitor monitor)
        {
            if (monitor == null)
            {
                throw new ArgumentNullException(nameof(monitor));
            }
            _context.Monitors.Remove(monitor);
        }

        public IEnumerable<Monitor> GetAllMonitors()
        {
            return _context.Monitors.ToList();
        }

        public Monitor GetMonitorById(int id)
        {
            return _context.Monitors.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateMonitor(Monitor monitor)
        {
            
        }
    }
}
