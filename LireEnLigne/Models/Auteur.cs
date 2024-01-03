namespace LireEnLigne.Models
{
	public class Auteur
	{


		[Required]
		public int AuteurID { get; set; }

		[Required]
		public required string AuteurName { get; set; }

		
		public string? Resume {  get; set; }

		public ICollection<Livre>? Livres { get; set; }


	}
}
