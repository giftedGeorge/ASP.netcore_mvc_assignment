using cybercafe_inventory_manager.Models;
using System.Collections.Generic;

namespace cybercafe_inventory_manager.Data
{
    public class MockInventoryRepo : IComputer
    {
        public void CreateComputer(Computer computer)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteComputer(Computer computer)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Computer> GetAllComputers()
        {
            var computers = new List<Computer>
            {
             new Computer{Id=0, brand="Acer", processor_speed=2.03F, number_of_cores=4, number_of_usb_ports=4, number_of_hdmi_ports=2},
             new Computer{Id=1, brand="Hp", processor_speed=2.4F, number_of_cores=3, number_of_usb_ports=2, number_of_hdmi_ports=3},
             new Computer{Id=2, brand="Dell", processor_speed=2.9F, number_of_cores=4, number_of_usb_ports=2, number_of_hdmi_ports=2},
            };

            return computers;
        }

        public Computer GetComputerById(int id)
        {
            return new Computer { Id = 0, brand = "Acer", processor_speed = 2.03F, number_of_cores = 4, number_of_usb_ports = 4, number_of_hdmi_ports = 2 };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateComputer(Computer computer)
        {
            throw new System.NotImplementedException();
        }
    }
}
