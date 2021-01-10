using System;
using mySeries.Classes;

namespace mySeries
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = setUserOption();

			while (userOption.ToUpper() != "X")
			{
				switch (userOption)
				{
					case "1":
						ListSeries();
						break;
					case "2":
						InsertSerie();
						break;
					case "3":
						UpdateSerie();
						break;
					case "4":
						DeleteSerie();
						break;
					case "5":
						ViewSerie();
						break;
					case "L":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}
            }
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
            
        }

        private static void DeleteSerie()
		{
			Console.Write("Digite o id da série: ");
			int indexSerie = int.Parse(Console.ReadLine());
            Console.WriteLine("Você tem certeza que ID:{0} deve ser deletado?",indexSerie);
            Console.WriteLine("Se sim digite '1' senão digite '2' ");
            int choose = int.Parse(Console.ReadLine());
            if (choose == 1)
            {
                repository.Delete(indexSerie);
            }
			
		}

        private static void ViewSerie()
		{
			Console.Write("Digite o id da série: ");
			int indexSerie = int.Parse(Console.ReadLine());

			var serie = repository.ReturnById(indexSerie);

			Console.WriteLine(serie);
		}

        private static void UpdateSerie()
		{
			Console.Write("Digite o id da série: ");
			int indexSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entryGenre = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entryTitle = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entryYear = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entryDescription = Console.ReadLine();

			Serie updateSerie = new Serie(id: indexSerie,
										genre: (Genre)entryGenre,
										title: entryTitle,
										year: entryYear,
										description: entryDescription);

			repository.Update(indexSerie, updateSerie);
		}

        private static void ListSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repository.List();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.returnDeleted();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.returnId(), serie.returnTitle(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InsertSerie()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entryGenre = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entryTitle = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entryYear = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entryDescription = Console.ReadLine();

			Serie newSerie = new Serie(id: repository.NextId(),
										genre: (Genre)entryGenre,
										title: entryTitle,
										year: entryYear,
										description: entryDescription);

			repository.Insert(newSerie);
		}

        private static string setUserOption()
		{
			Console.WriteLine();
			Console.WriteLine("mySeries aqui para lhe auxiliar!");
            Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("L- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string userOption = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return userOption;
		}
    }
}
