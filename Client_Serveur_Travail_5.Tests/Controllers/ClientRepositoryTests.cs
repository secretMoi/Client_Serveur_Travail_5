using System;
using System.Collections.Generic;
using System.Data.Entity;
using Client_Serveur_Travail_5.Models;
using Client_Serveur_Travail_5.Models.Interfaces;
using Client_Serveur_Travail_5.Models.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Client_Serveur_Travail_5.Tests.Controllers
{
	[TestClass]
	public class ClientRepositoryTests
	{
		private IClient<Client> _repo;

		[TestInitialize]
		public void Init_AvantChaqueTest()
		{
			IDatabaseInitializer<Travail5Context> init = new DropCreateDatabaseAlways<Travail5Context>();

			Database.SetInitializer(init);

			Travail5Context database = new Travail5Context();
			init.InitializeDatabase(database);

			_repo = new ClientRepository(database);
		}

		[TestMethod]
		public void GetById_ClientInexistant_RetourneNull()
		{
			Client result = _repo.GetById(55);

			Assert.IsNull(result);
		}

		[TestMethod]

		public void GetById_IdNonNumerique_RetourneNull()
		{
			Assert.IsNull(_repo.GetById(-1));
		}

		[TestMethod]
		public void Create()
		{
			_repo.Create(CreateModel());
			IList<Client> clients = _repo.GetAll();

			Assert.IsNotNull(clients);
			Assert.AreEqual(1, clients.Count);
			Assert.AreEqual(CreateModel().Nom, clients[0].Nom);
			Assert.AreEqual(CreateModel().Email, clients[0].Email);
			Assert.AreEqual(CreateModel().Password, clients[0].Password);
		}

		[TestMethod]
		public void Add_NouveauClientEtRecuperation_LeClientEstBienRecupere()
		{
			int result = _repo.Add(CreateModel());

			Assert.AreEqual(1, result);

			Client model = _repo.GetById(result);

			Assert.AreEqual(CreateModel().Nom, model.Nom);
			Assert.AreEqual(CreateModel().Email, model.Email);
			Assert.AreEqual(CreateModel().Password, model.Password);
		}

		[TestMethod]
		public void Authentify_LogMdpOk_AuthentifierOK()
		{
			int id = _repo.Add(CreateModel());
			var clientInBd = _repo.GetById(id);

			var client = _repo.Authentify(CreateModel());
			Assert.IsNotNull(clientInBd);
			Assert.IsNotNull(client);
			Assert.AreEqual(client.Nom, clientInBd.Nom);
			Assert.AreEqual(client.Email, clientInBd.Email);
			Assert.AreEqual(client.Password, clientInBd.Password);
		}

		[TestMethod]
		public void Authentify_LoginOkMdpKo_AuthentificationKO()
		{
			string fauxMDP = "Testiii";
			_repo.Add(CreateModel());
			var clientInBd = _repo.GetById(1);

			var client = _repo.Authentify(CreateModel());
			Assert.IsNotNull(clientInBd);
			Assert.IsNotNull(client);
			Assert.AreEqual(client.Nom, clientInBd.Nom);
			Assert.AreEqual(client.Email, clientInBd.Email);
			Assert.AreNotEqual(client.Password, fauxMDP);
		}

		[TestMethod]
		public void Authentify_LoginKoMdpOk_AuthentificationKO()
		{
			string fauxMail = "google@apple.yahoo";
			int id = _repo.Add(CreateModel());
			var clientInBd = _repo.GetById(id);

			var leClient = _repo.Authentify(CreateModel());
			Assert.IsNotNull(clientInBd);
			Assert.IsNotNull(leClient);
			Assert.AreEqual(leClient.Nom, clientInBd.Nom);
			Assert.AreNotEqual(leClient.Email, fauxMail);
			Assert.AreEqual(leClient.Password, clientInBd.Password);
		}

		[TestMethod]
		public void Authentifier_LoginMdpKo_AuthentificationKO()
		{
			string fauxMDP = "Testiii", fauxMail = "google@apple.yahoo";
			int id = _repo.Add(CreateModel());
			var clientInBd = _repo.GetById(id);

			var client = _repo.Authentify(CreateModel());
			Assert.IsNotNull(clientInBd);
			Assert.IsNotNull(client);
			Assert.AreEqual(client.Nom, clientInBd.Nom);
			Assert.AreNotEqual(client.Email, fauxMail);
			Assert.AreNotEqual(client.Password, fauxMDP);
		}

		private Client CreateModel()
		{
			return new Client()
			{
				Email = "toto@example.be",
				Nom = "tutu",
				Password = "cache"
			};
		}
	}
}
