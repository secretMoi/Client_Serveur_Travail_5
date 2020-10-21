using System;
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
	}
}