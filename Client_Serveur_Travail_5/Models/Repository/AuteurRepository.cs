using System;
using System.Collections.Generic;
using System.Linq;
using Client_Serveur_Travail_5.Models.Interfaces;

namespace Client_Serveur_Travail_5.Models.Repository
{
	public class AuteurRepository : IAuteur<Auteur>
	{
		public Travail5Context Context { get; set; }

		public AuteurRepository(Travail5Context context)
		{
			Context = context;
		}

		public IList<Auteur> GetAll()
		{
			return Context.Auteurs.ToList();
		}

		public Auteur GetById(int id)
		{
			// retourne le premier dont l'id correspond
			return Context.Auteurs
				//.Include(t => t.Locataire) // utilisé pour fill le lazy loading si foreign key null
				.FirstOrDefault(p => p.Id == id);
		}

		public int Add(Auteur model)
		{
			if (model == null)
				throw new ArgumentNullException(nameof(model));

			Context.Auteurs.Add(model);
			SaveChanges();

			return model.Id;
		}

		public bool SaveChanges()
		{
			// permet d'appliquer les modifications à la db
			return Context.SaveChanges() >= 0;
		}

		public void Create(Auteur model)
		{
			if (model == null)
				throw new ArgumentNullException(nameof(model));

			Context.Auteurs.Add(model);

			SaveChanges();
		}

		public void Modify(Auteur model)
		{
			if (model == null)
				throw new ArgumentNullException(nameof(model));

			Auteur modelInDb = GetById(model.Id);

			Context.Entry(modelInDb).CurrentValues.SetValues(model);

			SaveChanges();
		}

		public bool Exist(Auteur model)
		{
			return Context.Auteurs.Any(item => item.Nom == model.Nom);
		}
	}
}