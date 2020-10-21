using System.Data.Entity;

namespace Client_Serveur_Travail_5.Models
{
	public class Travail5Context : DbContext
	{
		public Travail5Context() : base("Travail5Context")
		{
			//Database.SetInitializer(new MigrateDatabaseToLatestVersion<Travail5Context, Migrations.Configuration>());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{

		}

		public DbSet<Client> Clients { get; set; }
		public DbSet<Musique> Musiques { get; set; }
		public DbSet<Auteur> Auteurs { get; set; }
		public DbSet<Emprunt> Emprunts { get; set; }
	}
}