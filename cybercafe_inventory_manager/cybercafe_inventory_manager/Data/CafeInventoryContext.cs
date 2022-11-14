using cybercafe_inventory_manager.Models;
using Microsoft.EntityFrameworkCore;

namespace cybercafe_inventory_manager.Data
{
    public class CafeInventoryContext : DbContext
    {
        public CafeInventoryContext(DbContextOptions<CafeInventoryContext> opt) : base(opt)
        {

        }

        public DbSet<Computer> Computers { get; set; }
        public DbSet<Mouse> Mice { get; set; }
        public DbSet<Keyboard> Keyboards { get; set; }
        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<Router> Routers { get; set; }
    }
}
