namespace Client_Serveur_Travail_5.Models.Interfaces
{
	public interface IAuteur<T> : IDal<T>
	{
		void Create(T model);

		void Modify(T model);

		bool Exist(T model);
	}
}
