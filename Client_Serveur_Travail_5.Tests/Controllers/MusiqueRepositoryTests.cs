using System;
using System.Data.Entity;
using Client_Serveur_Travail_5.Models;
using Client_Serveur_Travail_5.Models.Interfaces;
using Client_Serveur_Travail_5.Models.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Client_Serveur_Travail_5.Tests.Controllers
{
	[TestClass]
	public class MusiqueRepositoryTests
	{
		private IMusique<Musique> _repo;

		[TestInitialize]
		public void Init_AvantChaqueTest()
		{
			IDatabaseInitializer<Travail5Context> init = new DropCreateDatabaseAlways<Travail5Context>();

			Database.SetInitializer(init);

			Travail5Context database = new Travail5Context();
			init.InitializeDatabase(database);

			_repo = new MusiqueRepository(database);
		}

		[TestMethod]
		public void Add_NouvelleMusiqueEtRecuperation_LaMusiqueEstBienRecuperee()
		{
			Musique newMusique = CreateModel();
			_repo.Add(newMusique);
			var musique = _repo.GetById(1);

			Assert.IsNotNull(musique);
			Assert.AreEqual(musique.Id, 1);
			Assert.AreEqual(musique.Duree, newMusique.Duree);
			Assert.AreEqual(musique.Titre, newMusique.Titre);
			Assert.AreEqual(musique.Date, newMusique.Date);
			Assert.AreEqual(musique.Auteur.Id, 1);
		}

		private Musique CreateModel()
		{
			return new Musique()
			{
				Titre = "son qui tue",
				Duree = 5.32f,
				Date = DateTime.Now,
				Auteur = new Auteur()
				{
					Nom = "turlu",
					Prenom = "tutu"
				}
			};
		}
	}
}
