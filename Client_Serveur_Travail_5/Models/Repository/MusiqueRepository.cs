using System;
using System.Collections.Generic;
using System.Linq;
using Client_Serveur_Travail_5.Models.Interfaces;

namespace Client_Serveur_Travail_5.Models.Repository
{
	public class MusiqueRepository : IMusique<Musique>
	{
		public Travail5Context Context { get; set; }

		public MusiqueRepository(Travail5Context context)
		{
			Context = context;
		}

		public IList<Musique> GetAll()
		{
			return Context.Musiques.ToList();
		}

		public Musique GetById(int id)
		{
			// retourne le premier dont l'id correspond
			return Context.Musiques
				//.Include(t => t.Locataire) // utilisé pour fill le lazy loading si foreign key null
				.FirstOrDefault(p => p.Id == id);
		}

		public int Add(Musique model)
		{
			if (model == null)
				throw new ArgumentNullException(nameof(model));

			Context.Musiques.Add(model);
			SaveChanges();

			return model.Id;
		}

		public bool SaveChanges()
		{
			// permet d'appliquer les modifications à la db
			return Context.SaveChanges() >= 0;
		}
	}
}