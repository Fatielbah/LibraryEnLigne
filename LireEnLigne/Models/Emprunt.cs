namespace LireEnLigne.Models
{
	public class Emprunt
	{
		public int EmpruntID { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateEmprunt { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateRetourPrevue { get; set; }
        [DataType(DataType.Date)]
        public DateTime dateRetourEffective { get; set; }
		public int UserID { get; set; }
		public int ExemplaireID { get; set; }
		public User User { get; set; }
		public Exemplaire Exemplaire { get; set; }
	}
}
