namespace Client_Serveur_Travail_5.Models
{
	public class Emprunt
	{
		public int Id { get; set; }
		public virtual Client Client { get; set; }
		public virtual Musique Musique { get; set; }
	}
}