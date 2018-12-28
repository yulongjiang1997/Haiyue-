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

        public DbSet<Department> Department { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Currency> Currencys  { get; set; }

        public DbSet<NoteBook> NoteBooks { get; set; }

        public DbSet<TaskChangeLog> TaskChangeLogss { get; set; }

        public DbSet<TaskList> TaskLists { get; set; }

        public DbSet<TaskStatusLog> TaskStatusLogss { get; set; }

        public DbSet<Expenditure> Expenditures { get; set; }

        public DbSet<ExpenditureType> ExpenditureTypes { get; set; }


    }
}
