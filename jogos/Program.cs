using System;

namespace jogos
{
    class Program
    {
        static JogosRepositorio repositorio = new JogosRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarJogos();
						break;
					case "2":
						InserirJogo();
						break;
					case "3":
						AtualizarJogo();
						break;
					case "4":
						ExcluirJogo();
						break;
					case "5":
						VisualizarJogo();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirJogo()
		{
			Console.Write("Digite o id do jogo: ");
			int indiceJogo = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceJogo);
		}

        private static void VisualizarJogo()
		{
			Console.Write("Digite o id d jogo: ");
			int indiceJogo = int.Parse(Console.ReadLine());

			var jogo = repositorio.RetornaPorId(indiceJogo);

			Console.WriteLine(jogo);
		}

        private static void AtualizarJogo()
		{
			Console.Write("Digite o id do jogo: ");
			int indiceJogo = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Categorias)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categorias), i));
			}
			Console.Write("Digite a categorias entre as opções acima: ");
			int entradaCategorias = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Jogo: ");
			string entradaNome = Console.ReadLine();

            foreach (int i in Enum.GetValues(typeof(Classificacao)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Classificacao), i));
			}
			Console.Write("Digite a classificacao entre as opções acima: ");
			int entradaClassificacao = int.Parse(Console.ReadLine());

			Console.Write("Digite o Preço do Jogo: ");
			float entradaPreco = float.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Jogo: ");
			string entradaDescricao = Console.ReadLine();

			Jogos atualizaJogo = new Jogos(id: indiceJogo,
										Categorias: (Categorias)entradaCategorias,
										nome: entradaNome,
                                        Classificacao: (Classificacao)entradaClassificacao,
										preco: entradaPreco,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceJogo, atualizaJogo);
		}
        private static void ListarJogos()
		{
			Console.WriteLine("Listar jogos");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum jogo cadastrado.");
				return;
			}

			foreach (var jogo in lista)
			{
                var excluido = jogo.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} R$ {2} {3}", jogo.getId(), jogo.getNome(), jogo.getPreco(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirJogo()
		{
			Console.WriteLine("Inserir novo jogo");

			foreach (int i in Enum.GetValues(typeof(Categorias)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categorias), i));
			}
			Console.Write("Digite a categoria entre as opções acima: ");
			int entradaCategorias = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do jogo: ");
			string entradaNome = Console.ReadLine();

            foreach (int i in Enum.GetValues(typeof(Classificacao)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Classificacao), i));
			}
			Console.Write("Digite a classificacao entre as opções acima: ");
			int entradaClassificacao = int.Parse(Console.ReadLine());

			Console.Write("Digite o Preço do jogo: ");
			float entradaPreco = float.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do jogo: ");
			string entradaDescricao = Console.ReadLine();

			Jogos novoJogo = new Jogos(id: repositorio.ProximoId(),
										Categorias: (Categorias)entradaCategorias,
										nome: entradaNome,
                                        Classificacao: (Classificacao)entradaClassificacao,
										preco: entradaPreco,
										descricao: entradaDescricao);

			repositorio.Insere(novoJogo);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar jogos");
			Console.WriteLine("2- Inserir novo jogo");
			Console.WriteLine("3- Atualizar jogo");
			Console.WriteLine("4- Excluir jogo");
			Console.WriteLine("5- Visualizar jogo");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
