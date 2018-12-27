using Haiyue.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace Haiyue.HYEF
{
    public class HYContext : DbContext
    {
        public HYContext(DbContextOptions<HYContext> options):base(options)
        {

        }


        public DbSet<User> Users { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Currency> Currencys  { get; set; }
    }
}
