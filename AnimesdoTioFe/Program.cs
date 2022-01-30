
using AnimesdoTioFe;

class Progam
{
    static AnimesRepository repositorio = new AnimesRepository();
    private static void AtualizarSerie()
    {
        Console.Write("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());
      
        foreach (int i in Enum.GetValues(typeof(OpcoesDeAnime)))
        {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(OpcoesDeAnime), i));
        }
        Console.Write("Escolha o anime no qual deseja inserir um novo episódio entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Título do episódio: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano de lançamento do episódio: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a Descrição do epísódio: ");
        string entradaDescricao = Console.ReadLine();

        Animes atualizaAnime = new Animes(id: indiceSerie,
                                    Opcoes: (OpcoesDeAnime)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

        repositorio.Atualiza(indiceSerie, atualizaAnime);
    }

    private static void ExcluirSerie()
    {
        Console.Write("Digite o id do episódio: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        repositorio.Exclui(indiceSerie);
    }

    private static void InserirSerie()
    {
        Console.WriteLine("Inserir novo episódio");

        foreach (int i in Enum.GetValues(typeof(OpcoesDeAnime)))
        {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(OpcoesDeAnime), i));
        }
        Console.Write("Escolha o anime no qual deseja inserir um novo episódio entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Título do episódio: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano de de lançamento do episodio: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a Descrição do episódio: ");
        string entradaDescricao = Console.ReadLine();

        Animes novaSerie = new Animes(id: repositorio.ProximoId(),
                                    Opcoes: (OpcoesDeAnime)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

        repositorio.Insere(novaSerie);
    }
    private static void ListarSeries()
    {
        Console.WriteLine("Listar Animes");

        var lista = repositorio.Lista();

        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhum Anime cadastrada.");
            return;
        }

        foreach (var serie in lista)
        {
            var excluido = serie.retornaExcluido();

            Console.WriteLine("#ID {0}: - {1} {2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "*Excluído*" : ""));
        }
    }
    static void Main(string[] args)
    {
        string opcaoUsuario = ObterOpcaodoUsuario();

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
                    throw new ArgumentOutOfRangeException();
            }

            opcaoUsuario = ObterOpcaodoUsuario();
        }
        
        Console.WriteLine("------------------------------------------------------.");
        Console.WriteLine("Ficamos muito felizes por escolher os animes do Tio Fê.");
        Console.WriteLine("------------------------------------------------------.");
        Console.WriteLine("---------------------Obrigado!!!----------------------.");
        Console.WriteLine("------------------------------------------------------.");
        Console.ReadLine();
    }

    
    private static string ObterOpcaodoUsuario()
    {
        Console.WriteLine();
        Console.WriteLine("Seja bem vindo ao Animes do Tio Fê!!!");
        Console.WriteLine("Informe a opção desejada:");

        Console.WriteLine("1- Listar Animes");
        Console.WriteLine("2- Inserir novo episódio:");
        Console.WriteLine("3- Atualizar Animes:");
        Console.WriteLine("4- Excluir Animes:");
        Console.WriteLine("5- Visualizar Animes:");
        Console.WriteLine("C- Limpar Tela:");
        Console.WriteLine("X- Sair");
        Console.WriteLine("");

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;
    }

    private static void VisualizarSerie()
    {
        Console.Write("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        var serie = repositorio.RetornaPorId(indiceSerie);

        Console.WriteLine(serie);
    }
           
}