//Screen Sound
string mensagensDeBoasVindas = "Boas vindas ao curso de Screen Sound";
List<string> bandasRegistradas = new List<string> { "U2", "The Beatles", "Calypsu"};
Dictionary<string, List<int>> notasDasBandas = new Dictionary<string, List<int>>();

// Inicializar o dicionário com as bandas existentes
foreach (string banda in bandasRegistradas)
{
    notasDasBandas[banda] = new List<int>();
}

void exibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝

░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░░██████╗
██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗██╔════╝
╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║╚█████╗░
░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║░╚═══██╗
██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝██████╔╝
╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░╚═════╝░
");
    Console.WriteLine(mensagensDeBoasVindas);
}

void exibirFuncoesDoMenu()
{
    exibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 5 para exibir detalhes de uma banda");
    Console.WriteLine("Digite -1 para sair");

    int opcaoEscolhidaNumeros = lerOpcaoMenuValida();

    switch (opcaoEscolhidaNumeros)
    {
        case 1:
            registrarBanda();
            break;
        case 2:
            mostrarBandasRegistradas();
            break;
        case 3:
            avaliarBanda();
            break;
        case 4:
            exibirMediaBanda();
            break;
        case 5:
            exibirDetalhesBanda();
            break;
        case -1:
            Console.WriteLine("Tchau, tchau ;)");
            break;
        default:
            Console.WriteLine("Opção inválida, tente novamente.");
            exibirFuncoesDoMenu();
            break;
    }
}

int lerOpcaoMenuValida()
{
    int opcao;
    while (true)
    {
        Console.Write("\nDigite a opção desejada: ");
        string opcaoEscolhida = (Console.ReadLine() ?? "").Trim();

        if (int.TryParse(opcaoEscolhida, out opcao))
            return opcao;

        Console.WriteLine("Entrada inválida. Digite um número válido.");
    }
}

void registrarBanda()
{
    Console.Clear();
    Console.WriteLine("Você escolheu: Registrar uma banda\n");
    Console.Write("Digite o nome da nova banda: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (!bandasRegistradas.Contains(nomeDaBanda))
    {
        bandasRegistradas.Add(nomeDaBanda);
        notasDasBandas[nomeDaBanda] = new List<int>();
        Console.WriteLine($"Banda {nomeDaBanda} registrada com sucesso!");
    }
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} já está registrada!");
    }

    Thread.Sleep(2000);
    Console.Clear();
    exibirFuncoesDoMenu();
}

void mostrarBandasRegistradas()
{
    Console.Clear();
    Console.WriteLine("Você escolheu: Mostrar todas as bandas\n");
    foreach (string banda in bandasRegistradas)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
    Console.Clear();   
    exibirFuncoesDoMenu();
}

void avaliarBanda()
{
    Console.Clear();
    Console.WriteLine("Avaliar uma banda\n");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (!notasDasBandas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
        Thread.Sleep(2000);
        Console.Clear();
        exibirFuncoesDoMenu();
        return;
    }

    Console.Write($"Digite a nota para {nomeDaBanda}: ");
    string notaString = Console.ReadLine()!;

    if (int.TryParse(notaString, out int nota) && nota >= 0 && nota <= 10)
    {
        notasDasBandas[nomeDaBanda].Add(nota);
        Console.WriteLine($"Nota {nota} registrada com sucesso para {nomeDaBanda}!");
    }
    else
    {
        Console.WriteLine("Nota inválida. Digite um número entre 0 e 10.");
    }

    Thread.Sleep(2000);
    Console.Clear();
    exibirFuncoesDoMenu();
}

void exibirMediaBanda()
{
    Console.Clear();
    Console.WriteLine("Exibir a média de uma banda*\n");
    Console.Write("Digite o nome da banda para consultar a média: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (!notasDasBandas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
        Thread.Sleep(2000);
        Console.Clear();
        exibirFuncoesDoMenu();
        return;
    }

    List<int> notas = notasDasBandas[nomeDaBanda];

    if (notas.Count == 0)
    {
        Console.WriteLine($"A banda {nomeDaBanda} não possui nenhuma avaliação ainda.");
    }
    else
    {
        double media = notas.Average();
        Console.WriteLine($"\nA média de notas da banda {nomeDaBanda} é: {media:F2}");
    }

    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
    Console.Clear();
    exibirFuncoesDoMenu();
}

void exibirDetalhesBanda()
{
    Console.Clear();
    Console.WriteLine("Exibir Detalhes de uma Banda\n");
    Console.Write("Digite o nome da banda para consultar os detalhes: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (!notasDasBandas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
        Thread.Sleep(2000);
        Console.Clear();
        exibirFuncoesDoMenu();
        return;
    }

    List<int> notas = notasDasBandas[nomeDaBanda];
    Console.WriteLine($"\n--- Detalhes da Banda: {nomeDaBanda} ---");

    if (notas.Count == 0)
    {
        Console.WriteLine("Esta banda não possui nenhuma avaliação ainda.");
    }
    else
    {
        Console.WriteLine($"Total de avaliações: {notas.Count}");
        Console.WriteLine($"Avaliações: {string.Join(", ", notas)}");
        double media = notas.Average();
        Console.WriteLine($"Média de notas: {media:F2}");
    }

    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
    Console.Clear();
    exibirFuncoesDoMenu();
}

exibirFuncoesDoMenu();
