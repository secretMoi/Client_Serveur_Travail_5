using System.Collections.Generic;
using System.Web.Mvc;
using Client_Serveur_Travail_5.Models;
using Client_Serveur_Travail_5.Models.Repository;

namespace Client_Serveur_Travail_5.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ClientRepository repo = new ClientRepository(new Travail5Context());

			IList<Client> clients = repo.GetAll();

			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}