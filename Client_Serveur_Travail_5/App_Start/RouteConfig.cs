using System.Web.Mvc;
using System.Web.Routing;

namespace Client_Serveur_Travail_5
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "AfficherMusiques",
				url: "Afficher",
				defaults: new { controller = "Application", action = "Afficher" }
			);

			routes.MapRoute(
				name: "AfficherAuteurs",
				url: "Afficher/Auteurs",
				defaults: new { controller = "Application", action = "AfficherAuteurs" }
			);

			routes.MapRoute(
				name: "Musique",
				url: "Musique/{id}",
				defaults: new { controller = "Application", action = "Musique", id = UrlParameter.Optional }
			);

			routes.MapRoute(
				name: "ListeFromAuteur",
				url: "Afficher/Auteur/{id}",
				defaults: new { controller = "Application", action = "ListeFromAuteur", id = UrlParameter.Optional }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
