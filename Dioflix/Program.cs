using System;

namespace Dioflix
{
    class Program
    {
        static void Main(string[] args)
        {
            string userSelection = getUserSelection();

            while (userSelection.ToUpper() != "X")
            {
                switch (userSelection)
                {
                    case "1":
                        showSeriesOptions("series");
                        break;
                    case "2":
                        showMoviesOptions("movies");
                        break;
                    case "3":
                        showAnimesOptions("animes");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userSelection = getUserSelection();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");

        }

        private static string showSeriesOptions(string s)
        {
            string userOption = getUserOption(s);

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        Serie.SerieActions.ListSeries();
                        break;
                    case "2":
                        Serie.SerieActions.AddSerie();
                        break;
                    case "3":
                        Serie.SerieActions.UpdateSerie();
                        break;
                    case "4":
                        Serie.SerieActions.DeleteSerie();
                        break;
                    case "5":
                        Serie.SerieActions.VisualizeSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = getUserOption(s);
            }
            return "X";
        }

        private static string showMoviesOptions(string s)
        {
            string userOption = getUserOption(s);

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        Movie.MovieActions.ListMovies();
                        break;
                    case "2":
                        Movie.MovieActions.AddMovie();
                        break;
                    case "3":
                        Movie.MovieActions.UpdateMovie();
                        break;
                    case "4":
                        Movie.MovieActions.DeleteMovie();
                        break;
                    case "5":
                        Movie.MovieActions.VisualizeMovie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = getUserOption(s);
            }
            return "X";
        }

        private static string showAnimesOptions(string s)
        {
            string userOption = getUserOption(s);

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        Anime.AnimeActions.ListAnimes();
                        break;
                    case "2":
                        Anime.AnimeActions.AddAnime();
                        break;
                    case "3":
                        Anime.AnimeActions.UpdateAnime();
                        break;
                    case "4":
                        Anime.AnimeActions.DeleteAnime();
                        break;
                    case "5":
                        Anime.AnimeActions.VisualizeAnime();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = getUserOption(s);
            }
            return "X";

        }
        private static string getUserSelection()
        {
            Console.WriteLine();
            Console.WriteLine("Dioflix at your disposal!");
            Console.WriteLine("Inform desired option:");

            Console.WriteLine("1- Navigate to series");
            Console.WriteLine("2- Navigate to movies");
            Console.WriteLine("3- Navigate to animes");
            Console.WriteLine("X- Leave");
            Console.WriteLine();

            string userSelection = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userSelection;
        }
        private static string getUserOption(string s)
        {
            Console.WriteLine();
            Console.WriteLine("Dioflix a seu dispor!!!");
            Console.WriteLine("Inform desired option:");

            Console.WriteLine($"1- List {s}");
            Console.WriteLine($"2- Add new {s}");
            Console.WriteLine($"3- Update {s}");
            Console.WriteLine($"4- Delete {s}");
            Console.WriteLine($"5- Visualize {s}");
            Console.WriteLine($"C- Clear screen");
            Console.WriteLine($"X- Leave");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
