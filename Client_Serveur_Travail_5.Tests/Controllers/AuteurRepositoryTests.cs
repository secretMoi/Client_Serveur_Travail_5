using System.Collections.Generic;
using System.Data.Entity;
using Client_Serveur_Travail_5.Models;
using Client_Serveur_Travail_5.Models.Interfaces;
using Client_Serveur_Travail_5.Models.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Client_Serveur_Travail_5.Tests.Controllers
{
	[TestClass]
	public class AuteurRepositoryTests
	{
		private IAuteur<Auteur> _repo;

		[TestInitialize]
		public void Init_AvantChaqueTest()
		{
			IDatabaseInitializer<Travail5Context> init = new DropCreateDatabaseAlways<Travail5Context>();

			Database.SetInitializer(init);

			Travail5Context database = new Travail5Context();
			init.InitializeDatabase(database);

			_repo = new AuteurRepository(database);
		}

		[TestMethod]
		public void Create_AvecUnNouvelAuteur_ObtientTousLesAuteursRenvoitBienLAuteur()
		{
			_repo.Create(CreateModel());
			IList<Auteur> lAuteurs = _repo.GetAll();

			Assert.IsNotNull(lAuteurs);
			Assert.AreEqual(1, lAuteurs.Count);
			Assert.AreEqual(CreateModel().Nom, lAuteurs[0].Nom);
			Assert.AreEqual(CreateModel().Prenom, lAuteurs[0].Prenom);
		}
		
		[TestMethod]
		public void Modify_CreationDUnNouvelAuteurEtChangementNomEtPrenom_LaModificationEstCorrecteApresRechargement()
		{
			_repo.Create(CreateModel());

			Auteur newAuteur = new Auteur { Id = 1, Nom = "Damsin", Prenom = "Sébastien" };
			_repo.Modify(newAuteur);
			IList<Auteur> lAuteurs = _repo.GetAll();

			Assert.IsNotNull(lAuteurs);
			Assert.AreEqual(1, lAuteurs.Count);
			Assert.AreEqual(newAuteur.Id, lAuteurs[0].Id);
			Assert.AreEqual(newAuteur.Nom, lAuteurs[0].Nom);
			Assert.AreEqual(newAuteur.Prenom, lAuteurs[0].Prenom);
		}

		[TestMethod]
		public void Exist_AvecCreationDunAuteur_RenvoiQuilExiste()
		{
			_repo.Create(CreateModel());

			Assert.IsTrue(_repo.Exist(CreateModel()));
		}

		[TestMethod]
		public void Exist_AvecAuteurInexistant_RenvoiQuilExiste()
		{
			Assert.IsFalse(_repo.Exist(CreateModel()));
		}

		private Auteur CreateModel()
		{
			return new Auteur()
			{
				Nom = "coucou",
				Prenom = "toi"
			};
		}
	}
}
