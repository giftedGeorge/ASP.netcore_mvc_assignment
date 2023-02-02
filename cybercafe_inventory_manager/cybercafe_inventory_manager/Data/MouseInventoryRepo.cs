using cybercafe_inventory_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cybercafe_inventory_manager.Data
{
    public class MouseInventoryRepo : IMouseRepository
    {
        private readonly CafeInventoryContext _context;

        public MouseInventoryRepo(CafeInventoryContext context)
        {
            _context = context;
        }

        public void CreateMouse(Mouse mouse)
        {
            if (mouse == null)
            {
                throw new ArgumentNullException(nameof(mouse));
            }
            _context.Mice.Add(mouse);
        }

        public void DeleteMouse(Mouse mouse)
        {
            if (mouse == null)
            {
                throw new ArgumentNullException(nameof(mouse));
            }
            _context.Mice.Remove(mouse);
        }

        public IEnumerable<Mouse> GetAllMice()
        {
            return _context.Mice.ToList();
        }

        public Mouse GetMouseById(int id)
        {
            return _context.Mice.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateMouse(Mouse mouse)
        {
            
        }
    }
}
