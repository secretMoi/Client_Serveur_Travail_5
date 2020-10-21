using System;
using System.Collections.Generic;
using System.Linq;
using Client_Serveur_Travail_5.Models.Interfaces;

namespace Client_Serveur_Travail_5.Models.Repository
{
	public class ClientRepository : IClient<Client>
	{
		private readonly Travail5Context _context;
		public Travail5Context Context => _context;

		public ClientRepository(Travail5Context context)
		{
			_context = context;
		}

		public IList<Client> GetAll()
		{
			return _context.Clients.ToList(); // retourne la liste des commandes
		}

		public Client GetById(int id)
		{
			// retourne le premier dont l'id correspond
			return _context.Clients
				//.Include(t => t.Locataire) // utilisé pour fill le lazy loading si foreign key null
				.FirstOrDefault(p => p.Id == id);
		}

		public int Add(Client model)
		{
			if (model == null)
				throw new ArgumentNullException(nameof(model));

			_context.Clients.Add(model);
			SaveChanges();

			return model.Id;
		}

		public bool SaveChanges()
		{
			// permet d'appliquer les modifications à la db
			return _context.SaveChanges() >= 0;
		}

		public void Create(Client model)
		{
			if (model == null)
				throw new ArgumentNullException(nameof(model));

			_context.Clients.Add(model);

			SaveChanges();
		}

		public void Modify(Client model)
		{
			if (model == null)
				throw new ArgumentNullException(nameof(model));

			Client modelInDb = GetById(model.Id);
			Maper.Map(model, modelInDb);

			SaveChanges();
		}

		public bool Exist(Client model)
		{
			return _context.Clients.Any(client => client.Nom == model.Nom);
		}
	}
}