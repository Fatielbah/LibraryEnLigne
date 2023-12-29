namespace LireEnLigne.Models
{
	public class Reservation
	{
		public int ReservationID { get; set; }
		public DateTime DateDemande { get; set; }
		public DateTime DateReservation { get; set; }
		public DateTime DateAnnulation { get; set; }
		public int ExemplaireID { get; set; }
		public int UserID { get; set; }
		public User User { get; set; }
		public Exemplaire Exemplaire { get; set; }
	}
}
