using cybercafe_inventory_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cybercafe_inventory_manager.Data
{
    public class KeyboardInventoryRepo : IKeyboardRepository
    {
        private readonly CafeInventoryContext _context;

        public KeyboardInventoryRepo(CafeInventoryContext context)
        {
            _context = context;
        }

        public void CreateKeyboard(Keyboard keyboard)
        {
            if (keyboard == null)
            {
                throw new ArgumentNullException(nameof(keyboard));
            }
            _context.Keyboards.Add(keyboard);
        }

        public void DeleteKeyboard(Keyboard keyboard)
        {
            if (keyboard == null)
            {
                throw new ArgumentNullException(nameof(keyboard));
            }
            _context.Keyboards.Remove(keyboard);
        }

        public IEnumerable<Keyboard> GetAllKeyboards()
        {
            return _context.Keyboards.ToList();
        }

        public Keyboard GetKeyboardById(int id)
        {
            return _context.Keyboards.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateKeyboard(Keyboard keyboard)
        {
            
        }
    }
}
