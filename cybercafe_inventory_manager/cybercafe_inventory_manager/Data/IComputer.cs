using cybercafe_inventory_manager.Models;
using System.Collections.Generic;

namespace cybercafe_inventory_manager.Data
{
    public interface IComputer
    {
        bool SaveChanges();

        //get methods
        IEnumerable<Computer> GetAllComputers();
        Computer GetComputerById(int id);

        //post method
        void CreateComputer(Computer computer);

        //Put method
        void UpdateComputer(Computer computer);

        //Delete method
        void DeleteComputer(Computer computer);
    }
}
