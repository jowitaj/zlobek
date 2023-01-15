using Microsoft.EntityFrameworkCore;

namespace zlobek.Entities
{
    public class nurseryDbContext : DbContext
    {
        private string _connectionString = "Server=localhost;Database=master;Database=zlobek;Trusted_Connection=True;";

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Child> Child { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
