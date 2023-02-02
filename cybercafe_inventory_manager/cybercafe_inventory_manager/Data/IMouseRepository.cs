using cybercafe_inventory_manager.Models;
using System.Collections.Generic;

namespace cybercafe_inventory_manager.Data
{
    public interface IMouseRepository
    {
        bool SaveChanges();

        //get methods
        IEnumerable<Mouse> GetAllMice();
        Mouse GetMouseById(int id);

        //post method
        void CreateMouse(Mouse mouse);

        //Put method
        void UpdateMouse(Mouse mouse);

        //Delete method
        void DeleteMouse(Mouse mouse);
    }
}
