using cybercafe_inventory_manager.Models;
using System.Collections.Generic;

namespace cybercafe_inventory_manager.Data
{
    public interface IKeyboardRepository
    {
        bool SaveChanges();

        //get methods
        IEnumerable<Keyboard> GetAllKeyboards();
        Keyboard GetKeyboardById(int id);

        //post method
        void CreateKeyboard(Keyboard keyboard);

        //Put method
        void UpdateKeyboard(Keyboard keyboard);

        //Delete method
        void DeleteKeyboard(Keyboard keyboard);
    }
}
