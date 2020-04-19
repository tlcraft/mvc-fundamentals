using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class EfContext : DbContext
    {
        public EfContext(DbContextOptions<EfContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GenreType> GenreType {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(local);Database=UserDb;Trusted_Connection=True;");
        }
    }
}
