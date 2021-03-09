using System.Collections.Generic;
using Dioflix.Interfaces;

namespace Dioflix
{
	public class AnimeRepository : IRepositorio<Anime>
	{
        private List<Anime> animeList = new List<Anime>();
		public void Atualiza(int id, Anime objeto)
		{
			animeList[id] = objeto;
		}

		public void Exclui(int id)
		{
			animeList[id].Excluir();
		}

		public void Insere(Anime objeto)
		{
			animeList.Add(objeto);
		}

		public List<Anime> Lista()
		{
			return animeList;
		}

		public int ProximoId()
		{
			return animeList.Count;
		}

		public Anime RetornaPorId(int id)
		{
			return animeList[id];
		}
	}
}