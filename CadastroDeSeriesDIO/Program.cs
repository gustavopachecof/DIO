using System;

namespace CadastroDeSeriesDIO
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoDoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentNullException();
                }

                opcaoUsuario = ObterOpcaoDoUsuario();
            }
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o ID da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            if (CheckOutOfBoundsID(idSerie))
            {
                return;
            }

            Console.WriteLine(repositorio.RetornaPorId(idSerie));
        }
        private static void ExcluirSerie()
        {
            Console.Write("Digite o ID da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            if (CheckOutOfBoundsID(idSerie))
            {
                return;
            }

            Console.WriteLine("Removendo a série {0}", repositorio.RetornaPorId(idSerie).RetornaTitulo());

            repositorio.Exclui(idSerie);
        }

        private static bool CheckOutOfBoundsID(int id)
        {
            if (id >= repositorio.ProximoId())
            {
                Console.WriteLine("ID inválido. Não existe nenhuma série cadastrada com o ID informado");
                return true;
            }
            return false;
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o ID da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            if (CheckOutOfBoundsID(idSerie))
            {
                return;
            }

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o número correspondente ao novo gênero da série: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie serie = new Serie(idSerie,
                                        (Genero)entradaGenero,
                                        entradaTitulo,
                                        entradaDescricao,
                                        entradaAno);

            repositorio.Atualiza(idSerie, serie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                if (serie.RetornaExcluido()) continue;
                Console.WriteLine("#ID {0} - {1}", serie.RetornaId(), serie.RetornaTitulo());
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            int[] valoresGenero = (int[])Enum.GetValues(typeof(Genero));

            foreach (int i in valoresGenero)
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o número correspondente ao gênero da série: ");
            int entradaGenero = int.Parse(Console.ReadLine());


            if (!Array.Exists<int>(valoresGenero, genero => genero == entradaGenero))
            {
                Console.WriteLine("Gênero inválido!");
                return;
            }

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(repositorio.ProximoId(),
                                        (Genero)entradaGenero,
                                        entradaTitulo,
                                        entradaDescricao,
                                        entradaAno);

            repositorio.Insere(novaSerie);

        }

        private static string ObterOpcaoDoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("######################################");
            Console.WriteLine("##       Repositório de Séries      ##");
            Console.WriteLine("######################################");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada.");
            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}
        
