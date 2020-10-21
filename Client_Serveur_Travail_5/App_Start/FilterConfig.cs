using System.Web;
using System.Web.Mvc;

namespace Client_Serveur_Travail_5
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
