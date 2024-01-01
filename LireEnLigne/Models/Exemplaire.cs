using System;

namespace LireEnLigne.Models
{
	public class Exemplaire
	{
		[Required]
		public  int ExemplaireID { get; set; }

		[Required]
		public required string Edition { get; set; }

		[Required]
		public Langue? Langue { get; set; }

		[Required]
		public Status? Status { get; set; }

		[Required]
		public int LivreID { get; set; }

		
		public Livre? Livre { get; set; }

		public ICollection<Reservation>? Reservations { get; set; }
		public ICollection<Emprunt>? Emprunts { get; set; }
	}
}
