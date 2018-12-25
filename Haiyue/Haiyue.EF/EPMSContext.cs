using EPMS.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class EPMSContext : DbContext
    {
        public EPMSContext(DbContextOptions<EPMSContext> options):base(options)
        {

        }


        public DbSet<User> Users { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Purchase> Purchases { get; set; }
    }
}
