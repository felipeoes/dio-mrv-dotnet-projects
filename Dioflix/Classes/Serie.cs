using System;

namespace Dioflix
{
    public class Serie : EntidadeBase
    {
        private Gender gender { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        public Serie(int id, Gender gender, string title, string description, int year)
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

        public class SerieActions
        {
            static SerieRepository serieRepository = new SerieRepository();
            public static void DeleteSerie()
            {

                Console.Write("Type serie's id: ");
                int serieIndex = int.Parse(Console.ReadLine());

                serieRepository.Delete(serieIndex);
            }

            public static void VisualizeSerie()
            {
                Console.Write("Type serie's id: ");
                int serieIndex = int.Parse(Console.ReadLine());

                var serie = serieRepository.ReturnByID(serieIndex);

                Console.WriteLine(serie);
            }

            public static void UpdateSerie()
            {
                Console.Write("Type serie's id: ");
                int serieIndex = int.Parse(Console.ReadLine());

                foreach (int i in Enum.GetValues(typeof(Gender)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
                }
                Console.Write("Choose a gender among the options above:");
                int genderInput = int.Parse(Console.ReadLine());

                Console.Write("Type serie's title: ");
                string titleInput = Console.ReadLine();

                Console.Write("Type serie's releasing year: ");
                int yearInput = int.Parse(Console.ReadLine());

                Console.Write("Type serie's description: ");
                string descriptionInput = Console.ReadLine();

                Serie updateSerie = new Serie(id: serieIndex,
                                            gender: (Gender)genderInput,
                                            title: titleInput,
                                            year: yearInput,
                                            description: descriptionInput);

                serieRepository.Update(serieIndex, updateSerie);
            }
            public static void ListSeries()
            {
                Console.WriteLine("Listing series");

                var lista = serieRepository.List();

                if (lista.Count == 0)
                {
                    Console.WriteLine("No serie found in database.");
                    return;
                }

                foreach (var serie in lista)
                {
                    var deleted = serie.retornadeleted();

                    Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornatitle(), (deleted ? "*Deleted*" : ""));
                }
            }

            public static void AddSerie()
            {
                Console.WriteLine("Adding a new serie");

                foreach (int i in Enum.GetValues(typeof(Gender)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
                }
                Console.Write("Choose a gender among the options above: ");
                int genderInput = int.Parse(Console.ReadLine());

                Console.Write("Type serie's title: ");
                string titleInput = Console.ReadLine();

                Console.Write("Type Series releasing year: ");
                int yearInput = int.Parse(Console.ReadLine());

                Console.Write("Type serie's description: ");
                string descriptionInput = Console.ReadLine();

                Serie newSerie = new Serie(id: serieRepository.NextId(),
                                            gender: (Gender)genderInput,
                                            title: titleInput,
                                            year: yearInput,
                                            description: descriptionInput);

                serieRepository.Add(newSerie);
            }
        }
    }
}