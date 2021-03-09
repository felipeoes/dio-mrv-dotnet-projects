using System.Collections.Generic;
using Dioflix.Interfaces;

namespace Dioflix
{
    public class MovieRepository : IRepositorio<Movie>
    {
        private List<Movie> movieList = new List<Movie>();
        public void Update(int id, Movie objeto)
        {
            movieList[id] = objeto;
        }

        public void Delete(int id)
        {
            movieList[id].Excluir();
        }

        public void Add(Movie objeto)
        {
            movieList.Add(objeto);
        }

        public List<Movie> List()
        {
            return movieList;
        }

        public int NextId()
        {
            return movieList.Count;
        }

        public Movie ReturnByID(int id)
        {
            return movieList[id];
        }
    }
}