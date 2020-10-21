namespace Client_Serveur_Travail_5.Models.Interfaces
{
	public interface IClient<T> : IDal<T>
	{
		void Create(T model);

		void Modify(T model);

		bool Exist(T model);
	}
}
