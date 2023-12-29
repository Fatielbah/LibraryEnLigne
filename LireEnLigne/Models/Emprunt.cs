namespace LireEnLigne.Models
{
	public class Emprunt
	{
		public int EmpruntID { get; set; }
		public DateTime DateEmprunt { get; set; }
		public DateTime DateRetourPrevue { get; set; }
		public DateTime dateRetourEffective { get; set; }
		public int UserID { get; set; }
		public int ExemplaireID { get; set; }
		public User User { get; set; }
		public Exemplaire Exemplaire { get; set; }
	}
}
