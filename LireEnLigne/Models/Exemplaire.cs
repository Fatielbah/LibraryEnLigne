using System;

namespace LireEnLigne.Models
{
	public class Exemplaire
	{
		public int ExemplaireID { get; set; }
		public string Edition { get; set; }
		public Langue? Langue { get; set; }
		public Status? Status { get; set; }
		public int LivreID { get; set; }
		public Livre Livre { get; set; }

		public ICollection<Reservation> Reservations { get; set; }
		public ICollection<Emprunt> Emprunts { get; set; }
	}
}
