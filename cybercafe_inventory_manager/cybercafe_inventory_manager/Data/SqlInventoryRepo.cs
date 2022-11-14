using cybercafe_inventory_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cybercafe_inventory_manager.Data
{
    public class SqlInventoryRepo : IComputer, IKeyboard, IMonitor, IMouse, IRouter
    {
        private readonly CafeInventoryContext _context;

        public SqlInventoryRepo(CafeInventoryContext context)
        {
            _context = context;
        }

        public void CreateComputer(Computer computer)
        {
            if(computer == null)
            {
                throw new ArgumentNullException(nameof(computer));
            }
            _context.Computers.Add(computer);
        }

        public void CreateKeyboard(Keyboard keyboard)
        {
            if (keyboard == null)
            {
                throw new ArgumentNullException(nameof(keyboard));
            }
            _context.Keyboards.Add(keyboard);
        }

        public void CreateMonitor(Monitor monitor)
        {
            if (monitor == null)
            {
                throw new ArgumentNullException(nameof(monitor));
            }
            _context.Monitors.Add(monitor);
        }

        public void CreateMouse(Mouse mouse)
        {
            if (mouse == null)
            {
                throw new ArgumentNullException(nameof(mouse));
            }
            _context.Mice.Add(mouse);
        }

        public void CreateRouter(Router router)
        {
            if (router == null)
            {
                throw new ArgumentNullException(nameof(router));
            }
            _context.Routers.Add(router);
        }

        public void DeleteComputer(Computer computer)
        {
            if (computer == null)
            {
                throw new ArgumentNullException(nameof(computer));
            }
            _context.Computers.Remove(computer);
        }

        public void DeleteKeyboard(Keyboard keyboard)
        {
            if (keyboard == null)
            {
                throw new ArgumentNullException(nameof(keyboard));
            }
            _context.Keyboards.Remove(keyboard);
        }

        public void DeleteMonitor(Monitor monitor)
        {
            if (monitor == null)
            {
                throw new ArgumentNullException(nameof(monitor));
            }
            _context.Monitors.Remove(monitor);
        }

        public void DeleteMouse(Mouse mouse)
        {
            if (mouse == null)
            {
                throw new ArgumentNullException(nameof(mouse));
            }
            _context.Mice.Remove(mouse);
        }

        public void DeleteRouter(Router router)
        {
            if (router == null)
            {
                throw new ArgumentNullException(nameof(router));
            }
            _context.Routers.Remove(router);
        }

        public IEnumerable<Computer> GetAllComputers()
        {
            return _context.Computers.ToList();
        }

        public IEnumerable<Keyboard> GetAllKeyboards()
        {
            return _context.Keyboards.ToList();
        }

        public IEnumerable<Mouse> GetAllMice()
        {
            return _context.Mice.ToList();
        }

        public IEnumerable<Monitor> GetAllMonitors()
        {
            return _context.Monitors.ToList();
        }

        public IEnumerable<Router> GetAllRouters()
        {
            return _context.Routers.ToList();
        }

        public Computer GetComputerById(int id)
        {
            return _context.Computers.FirstOrDefault(p => p.Id == id);
        }

        public Keyboard GetKeyboardById(int id)
        {
            return _context.Keyboards.FirstOrDefault(p => p.Id == id);
        }

        public Monitor GetMonitorById(int id)
        {
            return _context.Monitors.FirstOrDefault(p => p.Id == id);
        }

        public Mouse GetMouseById(int id)
        {
            return _context.Mice.FirstOrDefault(p => p.Id == id);
        }

        public Router GetRouterById(int id)
        {
            return _context.Routers.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateComputer(Computer computer)
        {

        }

        public void UpdateKeyboard(Keyboard keyboard)
        {

        }

        public void UpdateMonitor(Monitor monitor)
        {

        }

        public void UpdateMouse(Mouse mouse)
        {

        }

        public void UpdateRouter(Router router)
        {

        }
    }
}
