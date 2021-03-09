using System.Collections.Generic;
using Dioflix.Interfaces;

namespace Dioflix
{
    public class SerieRepository : IRepositorio<Serie>
    {
        private List<Serie> serieList = new List<Serie>();
        public void Update(int id, Serie objeto)
        {
            serieList[id] = objeto;
        }

        public void Delete(int id)
        {
            serieList[id].Excluir();
        }

        public void Add(Serie objeto)
        {
            serieList.Add(objeto);
        }

        public List<Serie> List()
        {
            return serieList;
        }

        public int NextId()
        {
            return serieList.Count;
        }

        public Serie ReturnByID(int id)
        {
            return serieList[id];
        }

    }
}