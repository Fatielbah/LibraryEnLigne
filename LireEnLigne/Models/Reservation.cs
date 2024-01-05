namespace LireEnLigne.Models
{
	public class Reservation
	{
		public int ReservationID { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateDemande { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateReservation { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAnnulation { get; set; }
		public int ExemplaireID { get; set; }
		public int UserID { get; set; }
		public User? User { get; set; }
		public Exemplaire? Exemplaire { get; set; }
	}
}
