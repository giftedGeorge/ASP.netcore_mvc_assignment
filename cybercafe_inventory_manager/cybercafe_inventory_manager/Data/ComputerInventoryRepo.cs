using cybercafe_inventory_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cybercafe_inventory_manager.Data
{
    public class ComputerInventoryRepo : IComputerRepository
    {
        private readonly CafeInventoryContext _context;

        public ComputerInventoryRepo(CafeInventoryContext context)
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

        public void DeleteComputer(Computer computer)
        {
            if (computer == null)
            {
                throw new ArgumentNullException(nameof(computer));
            }
            _context.Computers.Remove(computer);
        }

        public IEnumerable<Computer> GetAllComputers()
        {
            return _context.Computers.ToList();
        }

        public Computer GetComputerById(int id)
        {
            return _context.Computers.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateComputer(Computer computer)
        {
            
        }
    }
}
