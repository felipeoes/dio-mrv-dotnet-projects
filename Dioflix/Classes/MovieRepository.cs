using System.Collections.Generic;
using Dioflix.Interfaces;

namespace Dioflix
{
	public class MovieRepository : IRepositorio<Movie>
	{
        private List<Movie> movieList = new List<Movie>();
		public void Atualiza(int id, Movie objeto)
		{
			movieList[id] = objeto;
		}

		public void Exclui(int id)
		{
			movieList[id].Excluir();
		}

		public void Insere(Movie objeto)
		{
			movieList.Add(objeto);
		}

		public List<Movie> Lista()
		{
			return movieList;
		}

		public int ProximoId()
		{
			return movieList.Count;
		}

		public Movie RetornaPorId(int id)
		{
			return movieList[id];
		}
	}
}