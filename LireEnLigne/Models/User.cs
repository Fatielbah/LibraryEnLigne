using System.ComponentModel.DataAnnotations;

namespace LireEnLigne.Models
{
	public class User
	{
		public int Id { get; set; }

		[Required]
		public required string Nom { get; set; }

		[Required]
		public required string Prenom { get; set; }

		[Required]
		[EmailAddress]
		public required string Email { get; set; }

		[Required]
		public required string NumeroTelephone { get; set; }

		[Required]
		public required string Adresse { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public required string Password { get; set; }

		public required byte[] Salt { get; set; }
		[Required]
		public Role? Role { get; set; }

		public ICollection<Reservation>? Reservations { get; set; }
		public ICollection<Emprunt>? Emprunts { get; set; }
	}
}
