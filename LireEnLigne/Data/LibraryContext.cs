

namespace LireEnLigne.Data
{
	public class LibraryContext : DbContext
	{
		public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
		{

		}

		public DbSet <User> Users { get; set; }
		public DbSet<Livre> Livres { get; set; }
		public DbSet<Emprunt> Emprunts { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
		public DbSet<Exemplaire> Exemplaires { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().ToTable("User");
			modelBuilder.Entity<Livre>().ToTable("Livre");
			modelBuilder.Entity<Emprunt>().ToTable("Emprunt");
			modelBuilder.Entity<Reservation>().ToTable("Reservation");
			modelBuilder.Entity<Exemplaire>().ToTable("Exemplaire");

		}

	}
}
