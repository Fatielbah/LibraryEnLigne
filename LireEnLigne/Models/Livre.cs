namespace LireEnLigne.Models
{
	public class Livre
	{
		// [DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int LivreID { get; set; }
		public string Isbn { get; set; }
		public string Titre { get; set; }
		public int NbreExemplaire { get; set; }
		public int NbrePages { get; set; }
		public DateTime DatePublication { get; set; }
		public string Resume { get; set; }
		public Genre? Genre { get; set; }
		public ICollection<Exemplaire> Exemplaires { get; set; }
	}
}
