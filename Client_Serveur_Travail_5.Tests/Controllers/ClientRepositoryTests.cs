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
		public void Create()
		{
			Client model = new Client()
			{
				Email = "toto@example.be",
				Nom = "tutu",
				Password = "cache"
			};
			_repo.Create(model);
			IList<Client> clients = _repo.GetAll();

			Assert.IsNotNull(clients);
			Assert.AreEqual(1, clients.Count);
			Assert.AreEqual("tutu", clients[0].Nom);
			Assert.AreEqual("toto@example.be", clients[0].Email);
			Assert.AreEqual("cache", clients[0].Password);
		}

		[TestMethod]
		public void Add()
		{
			Client model = new Client()
			{
				Email = "toto@example.be",
				Nom = "tutu",
				Password = "cache"
			};
			int result = _repo.Add(model);

			Assert.AreEqual(1, result);

			model = _repo.GetById(result);

			Assert.AreEqual("tutu", model.Nom);
			Assert.AreEqual("toto@example.be", model.Email);
			Assert.AreEqual("cache", model.Password);
		}
	}
}
