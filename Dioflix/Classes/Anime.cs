using System;

namespace Dioflix
{
    public class Anime : EntidadeBase
    {
        private Gender gender { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        public Anime(int id, Gender gender, string title, string description, int year)
        {
            this.Id = id;
            this.gender = gender;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.gender + Environment.NewLine;
            retorno += "title: " + this.Title + Environment.NewLine;
            retorno += "Descrição: " + this.Description + Environment.NewLine;
            retorno += "year de Início: " + this.Year + Environment.NewLine;
            retorno += "deleted: " + this.Deleted;
            return retorno;
        }

        public string retornatitle()
        {
            return this.Title;
        }

        public int retornaId()
        {
            return this.Id;
        }
        public bool retornadeleted()
        {
            return this.Deleted;
        }
        public void Excluir()
        {
            this.Deleted = true;
        }

        public class AnimeActions
        {
            static AnimeRepository animeRepository = new AnimeRepository();
            public static void DeleteAnime()
            {

                Console.Write("Type anime's id: ");
                int animeIndex = int.Parse(Console.ReadLine());

                animeRepository.Delete(animeIndex);
            }

            public static void VisualizeAnime()
            {
                Console.Write("Type anime's id: ");
                int animeIndex = int.Parse(Console.ReadLine());

                var anime = animeRepository.ReturnByID(animeIndex);

                Console.WriteLine(anime);
            }

            public static void UpdateAnime()
            {
                Console.Write("Type anime's id: ");
                int animeIndex = int.Parse(Console.ReadLine());

                foreach (int i in Enum.GetValues(typeof(Gender)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
                }
                Console.Write("Choose a gender among the options above:");
                int genderInput = int.Parse(Console.ReadLine());

                Console.Write("Type anime's title: ");
                string titleInput = Console.ReadLine();

                Console.Write("Type anime's releasing year: ");
                int yearInput = int.Parse(Console.ReadLine());

                Console.Write("Type anime's description: ");
                string descriptionInput = Console.ReadLine();

                Anime updateAnime = new Anime(id: animeIndex,
                                            gender: (Gender)genderInput,
                                            title: titleInput,
                                            year: yearInput,
                                            description: descriptionInput);

                animeRepository.Update(animeIndex, updateAnime);
            }
            public static void ListAnimes()
            {
                Console.WriteLine("Listing animes");

                var lista = animeRepository.List();

                if (lista.Count == 0)
                {
                    Console.WriteLine("No anime found in database.");
                    return;
                }

                foreach (var anime in lista)
                {
                    var deleted = anime.retornadeleted();

                    Console.WriteLine("#ID {0}: - {1} {2}", anime.retornaId(), anime.retornatitle(), (deleted ? "*Deleted*" : ""));
                }
            }

            public static void AddAnime()
            {
                Console.WriteLine("Adding a new anime");

                foreach (int i in Enum.GetValues(typeof(Gender)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
                }
                Console.Write("Choose a gender among the options above: ");
                int genderInput = int.Parse(Console.ReadLine());

                Console.Write("Type anime's title: ");
                string titleInput = Console.ReadLine();

                Console.Write("Type animes releasing year: ");
                int yearInput = int.Parse(Console.ReadLine());

                Console.Write("Type anime's description: ");
                string descriptionInput = Console.ReadLine();

                Anime newAnime = new Anime(id: animeRepository.NextId(),
                                            gender: (Gender)genderInput,
                                            title: titleInput,
                                            year: yearInput,
                                            description: descriptionInput);

                animeRepository.Add(newAnime);
            }
        }
    }
}