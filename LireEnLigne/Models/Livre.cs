namespace LireEnLigne.Models
{
	public class Livre
	{
		// [DatabaseGenerated(DatabaseGeneratedOption.None)]

		[Required]
		public int LivreID { get; set; }
		[Required]
		public required string Isbn { get; set; }
		[Required]
		public required string Titre { get; set; }
		[Required]
		public int NbreExemplaire { get; set; }
		[Required]
		public int NbrePages { get; set; }

		[Required]
		public DateTime DatePublication { get; set; }

		[Required]
		public required string Resume { get; set; }

		public byte[]? Image { get; set; }

		[Required]
		public required Genre Genre { get; set; }

		[Required]
		public int AuteurID { get; set; }

		public Auteur? Auteur { get; set; }


		public ICollection<Exemplaire>? Exemplaires { get; set; }
	}
}
