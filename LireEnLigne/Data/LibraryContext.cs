

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LireEnLigne.Data
{
	public class LibraryContext : DbContext
	{
		
			public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
			{

			}
			//configuration de base

			public DbSet<User> Users { get; set; }
			public DbSet<Livre> Livres { get; set; }
			public DbSet<Emprunt> Emprunts { get; set; }
			public DbSet<Reservation> Reservations { get; set; }
			public DbSet<Exemplaire> Exemplaires { get; set; }

			protected override void OnModelCreating(ModelBuilder modelBuilder)
			{
				//auto generated user id
				modelBuilder.Entity<User>()
				   .HasKey(u => u.Id)
				   .HasAnnotation("MySql: ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
				//auto generated livre id
				modelBuilder.Entity<Livre>()
				   .HasKey(l => l.LivreID)
				   .HasAnnotation("MySql: ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
				//auto generated exemplaire id
				modelBuilder.Entity<Exemplaire>()
				   .HasKey(e => e.ExemplaireID)
				   .HasAnnotation("MySql: ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);


				// auto generated emprunt id
				modelBuilder.Entity<Emprunt>()
				   .HasKey(em => em.EmpruntID)
				   .HasAnnotation("MySql: ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
				// auto generated reservation id

				modelBuilder.Entity<Reservation>()
				   .HasKey(r => r.ReservationID)
				   .HasAnnotation("MySql: ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

				modelBuilder.Entity<User>().ToTable("User");
				modelBuilder.Entity<Livre>().ToTable("Livre");
				modelBuilder.Entity<Emprunt>().ToTable("Emprunt");
				modelBuilder.Entity<Reservation>().ToTable("Reservation");
				modelBuilder.Entity<Exemplaire>().ToTable("Exemplaire");

				//configuring enum

				modelBuilder.Entity<User>()
				.Property(u => u.Role)
				.HasConversion<int>(); // Convert user role enum to int for storage

				modelBuilder.Entity<Livre>()
				.Property(l => l.Genre)
				.HasConversion<int>(); // Convert user genre enum to int for storage

				modelBuilder.Entity<Exemplaire>()
				.Property(e => e.Langue)
				.HasConversion<int>(); // Convert exemplaire langue enum to int for storage
				modelBuilder.Entity<Exemplaire>()
				.Property(e => e.Status)
				.HasConversion<int>(); // Convert exemplaire status enum to int for storage


			//enum  on user
			modelBuilder
			.Entity<User>()
			.Property(d => d.Role)
			.HasConversion(new EnumToStringConverter<Role>());

			//enum Langue on Exemplaire
			modelBuilder
			.Entity<Exemplaire>()
			.Property(d => d.Langue)
			.HasConversion(new EnumToStringConverter<Langue>());

			//enum status on exemplaire
			modelBuilder
			.Entity<Exemplaire>()
			.Property(d => d.Status)
			.HasConversion(new EnumToStringConverter<Status>());

			//enum genre on livre
			modelBuilder
			.Entity<Livre>()
			.Property(d => d.Genre)
			.HasConversion(new EnumToStringConverter<Genre>());

			base.OnModelCreating(modelBuilder);

			}

	}
}

