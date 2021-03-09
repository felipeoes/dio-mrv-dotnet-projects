using System;

namespace Dioflix
{
    public class Movie : EntidadeBase
    {
        private Gender gender { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        public Movie(int id, Gender gender, string title, string description, int year)
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

        public class MovieActions
        {
            static MovieRepository movieRepository = new MovieRepository();
            public static void DeleteMovie()
            {

                Console.Write("Type movie's id: ");
                int movieIndex = int.Parse(Console.ReadLine());

                movieRepository.Delete(movieIndex);
            }

            public static void VisualizeMovie()
            {
                Console.Write("Type movie's id: ");
                int movieIndex = int.Parse(Console.ReadLine());

                var movie = movieRepository.ReturnByID(movieIndex);

                Console.WriteLine(movie);
            }

            public static void UpdateMovie()
            {
                Console.Write("Type movie's id: ");
                int movieIndex = int.Parse(Console.ReadLine());

                foreach (int i in Enum.GetValues(typeof(Gender)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
                }
                Console.Write("Choose a gender among the options above:");
                int genderInput = int.Parse(Console.ReadLine());

                Console.Write("Type movie's title: ");
                string titleInput = Console.ReadLine();

                Console.Write("Type movie's releasing year: ");
                int yearInput = int.Parse(Console.ReadLine());

                Console.Write("Type movie's description: ");
                string descriptionInput = Console.ReadLine();

                Movie updateMovie = new Movie(id: movieIndex,
                                            gender: (Gender)genderInput,
                                            title: titleInput,
                                            year: yearInput,
                                            description: descriptionInput);

                movieRepository.Update(movieIndex, updateMovie);
            }
            public static void ListMovies()
            {
                Console.WriteLine("Listing movies");

                var lista = movieRepository.List();

                if (lista.Count == 0)
                {
                    Console.WriteLine("No movie found in database.");
                    return;
                }

                foreach (var movie in lista)
                {
                    var deleted = movie.retornadeleted();

                    Console.WriteLine("#ID {0}: - {1} {2}", movie.retornaId(), movie.retornatitle(), (deleted ? "*Deleted*" : ""));
                }
            }

            public static void AddMovie()
            {
                Console.WriteLine("Adding a new movie");

                foreach (int i in Enum.GetValues(typeof(Gender)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
                }
                Console.Write("Choose a gender among the options above: ");
                int genderInput = int.Parse(Console.ReadLine());

                Console.Write("Type movie's title: ");
                string titleInput = Console.ReadLine();

                Console.Write("Type movies releasing year: ");
                int yearInput = int.Parse(Console.ReadLine());

                Console.Write("Type movie's description: ");
                string descriptionInput = Console.ReadLine();

                Movie newMovie = new Movie(id: movieRepository.NextId(),
                                            gender: (Gender)genderInput,
                                            title: titleInput,
                                            year: yearInput,
                                            description: descriptionInput);

                movieRepository.Add(newMovie);
            }
        }
    }
}