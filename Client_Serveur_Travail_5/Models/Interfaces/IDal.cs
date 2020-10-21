using System.Collections.Generic;

namespace Client_Serveur_Travail_5.Models.Interfaces
{
	public interface IDal<T>
	{
		IList<T> GetAll();

		T GetById(int id);

		int Add(T model);

		bool SaveChanges();
	}
}
