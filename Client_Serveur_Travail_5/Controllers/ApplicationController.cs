using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Client_Serveur_Travail_5.Models;
using Client_Serveur_Travail_5.Models.Repository;
using Client_Serveur_Travail_5.ViewModels.Application;

namespace Client_Serveur_Travail_5.Controllers
{
	public class ApplicationController : Controller
	{
		public ActionResult Afficher()
		{
			MusiqueRepository repo = new MusiqueRepository(new Travail5Context());

			/*Musique model = new Musique()
			{
				Date = DateTime.Now,
				Duree = 3.49f,
				Titre = "gros minet"
			};
			repo.Add(model);*/

			Afficher viewModel = new Afficher
			{
				Musiques = repo.GetAll()
			};

			return View(viewModel);
		}

		public ActionResult AfficherAuteurs()
		{
			AuteurRepository repo = new AuteurRepository(new Travail5Context());

			/*Auteur model = new Auteur()
			{
				Nom = "rantan",
				Prenom = "plan"
			};
			repo.Add(model);*/

			AfficherAuteurs viewModel = new AfficherAuteurs
			{
				Auteurs = repo.GetAll()
			};

			return View(viewModel);
		}

		public ActionResult Musique(int id)
		{
			MusiqueRepository repo = new MusiqueRepository(new Travail5Context());

			Musique musique = repo.GetById(id);

			return View(musique);
		}

		public ActionResult ListeFromAuteur(int id)
		{
			MusiqueRepository repo = new MusiqueRepository(new Travail5Context());

			IList<Musique> musiques = 
				repo.GetAll()
				.Where(item => item.Auteur?.Id == id)
				.ToList();

			Afficher viewModel = new Afficher
			{
				Musiques = musiques
			};

			return View("Afficher", viewModel);
		}
	}
}