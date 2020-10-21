using System;

namespace Client_Serveur_Travail_5.Models
{
	public class Musique
	{
		public int Id { get; set; }
		public string Titre { get; set; }
		public float Duree { get; set; }
		public DateTime Date { get; set; }
		public virtual Auteur Auteur { get; set; }
	}
}