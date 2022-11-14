using cybercafe_inventory_manager.Models;
using System.Collections.Generic;

namespace cybercafe_inventory_manager.Data
{
    public interface IRouter
    {
        bool SaveChanges();

        //get methods
        IEnumerable<Router> GetAllRouters();
        Router GetRouterById(int id);

        //post method
        void CreateRouter(Router router);

        //Put method
        void UpdateRouter(Router router);

        //Delete method
        void DeleteRouter(Router router);
    }
}
