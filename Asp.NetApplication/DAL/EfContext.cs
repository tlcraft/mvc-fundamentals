using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class EfContext : DbContext
    {
        public EfContext(DbContextOptions<EfContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<GenreType> GenreType { get; set; }
        public DbSet<MembershipType> MembershipType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>()
                .HasOne(rental => rental.Game)
                .WithMany(game => game.Rentals)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rental>()
                .HasOne(rental => rental.User)
                .WithMany(user => user.Rentals)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
