using cybercafe_inventory_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cybercafe_inventory_manager.Data
{
    public class RouterInventoryRepo : IRouterRepository
    {
        private readonly CafeInventoryContext _context;

        public RouterInventoryRepo(CafeInventoryContext context)
        {
            _context = context;
        }
        public void CreateRouter(Router router)
        {
            if (router == null)
            {
                throw new ArgumentNullException(nameof(router));
            }
            _context.Routers.Add(router);
        }

        public void DeleteRouter(Router router)
        {
            if (router == null)
            {
                throw new ArgumentNullException(nameof(router));
            }
            _context.Routers.Remove(router);
        }

        public IEnumerable<Router> GetAllRouters()
        {
            return _context.Routers.ToList();
        }

        public Router GetRouterById(int id)
        {
            return _context.Routers.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateRouter(Router router)
        {
            
        }
    }
}
