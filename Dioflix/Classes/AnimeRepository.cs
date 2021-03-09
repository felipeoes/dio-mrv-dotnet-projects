using System.Collections.Generic;
using Dioflix.Interfaces;

namespace Dioflix
{
    public class AnimeRepository : IRepositorio<Anime>
    {
        private List<Anime> animeList = new List<Anime>();
        public void Update(int id, Anime objeto)
        {
            animeList[id] = objeto;
        }

        public void Delete(int id)
        {
            animeList[id].Excluir();
        }

        public void Add(Anime objeto)
        {
            animeList.Add(objeto);
        }

        public List<Anime> List()
        {
            return animeList;
        }

        public int NextId()
        {
            return animeList.Count;
        }

        public Anime ReturnByID(int id)
        {
            return animeList[id];
        }
    }
}