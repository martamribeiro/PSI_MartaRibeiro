using System;
using System.IO;

class Program
{
    // --------------------- Variáveis ---------------------

    public static List<Livro> livros = new List<Livro>();
    public static List<Utilizador> utilizadores = new List<Utilizador>();
    public const string ficheiroLivros = "livros.txt";
    public const string ficheiroUtilizadores = "utilizadores.txt";

    // ---------------------- Métodos ----------------------

    static void Main(string[] args)
    {

        CarregarLivros();
        CarregarUtilizadores();
        
        int opcao;

        do{

            // --------------------- Cabeçalho ---------------------

            Console.WriteLine("\n====== Gestor de Biblioteca ======\n");
            Console.WriteLine("====== Livros ======");
            Console.WriteLine("1. Listar livros");
            Console.WriteLine("2. Pesquisar livro");
            Console.WriteLine("3. Adicionar livro");
            Console.WriteLine("4. Requisitar livro"); //to-do
            Console.WriteLine("5. Devolver livro"); //to-do
            Console.WriteLine("6. Remover livro");
            Console.WriteLine("====== Utilizadores ======");
            Console.WriteLine("7. Adicionar utilizador");
            Console.WriteLine("8. Pesquisar utilizador"); //to-do
            Console.WriteLine("9. Remover utilizador"); //to-do
            Console.WriteLine("10. Listar utilizador"); //to-do
            Console.WriteLine("====== Outros ======");
            Console.WriteLine("0. Sair\n");
            Console.Write("Selecione uma opção: ");

            opcao = int.Parse(Console.ReadLine());

            // ---------------------- Opções ----------------------

            switch (opcao)
            {
                case 1:
                    // Listar livros
                    ListarLivros();
                    break;
                case 2:
                    // Pesquisar livro
                    PesquisarLivro();
                    break;
                case 3:
                    // Adicionar livro
                    AdicionarLivro();
                    break;
                case 4:
                    // Requisitar livro
                    RequisitarLivro();
                    break;
                case 5:
                    // Devolver livro - to-do
                    DevolverLivro();
                    break;
                case 6:
                    // Remover livro
                    RemoverLivro();
                    break;
                case 7:
                    // Adicionar utilizador
                    AdicionarUtilizador();
                    break;
                case 8:
                    // Pesquisar utilizador - to-do
                    PesquisarUtilizador();
                    break;
                case 9:
                    // Remover utilizador - to-do
                    RemoverUtilizador();
                    break;
                case 10:
                    // Listar utilizador - to-do
                    ListarUtilizador();
                    break;
                case 0:
                    // Sair
                    break;
                default:
                    // Outras opções
                    Console.WriteLine("A opção não existe.");
                    break;
            }

        } while (opcao != 0);
    }

    // --------------------------------------------------
    // --------------------- Livros ---------------------
    // --------------------------------------------------

    //Exemplo de Ficheiro livros.txt :
    //Harry Potter|J.K. Rowling|9781234567890|1997|Fantasia|True
    //1984|George Orwell|9789876543210|1949|Distopia|True
    private static void CarregarLivros()
    {
        if (!File.Exists(ficheiroLivros))
        {
            File.Create(ficheiroLivros);
        }

        string[] linhas = File.ReadAllLines(ficheiroLivros);
        foreach (string linha in linhas)
        {
            string[] dados = linha.Split('|');
            Livro livroNovo = new Livro
            {
                Título = dados[0],
                Autor = dados[1],
                ISBN = dados[2],
                AnoPublicacao = int.Parse(dados[3]),
                Genero = dados[4],
                Disponivel = bool.Parse(dados[5])
            };
            livros.Add(livroNovo);
        }
    }

    // ------------------ 1. Listar livros ------------------

    private static void ListarLivros()
    {
        Console.WriteLine("\n====== 1. Listar Livros ======");

        if (livros.Count == 0)
        {
            Console.WriteLine("\nNão existem livros catalogados.");
        }
        else
        {
            foreach (Livro livro in livros)
            {
                LivroInfo(livro);
            }
        }

    }

    public static void LivroInfo(Livro livro)
    {
        Console.WriteLine($"\n====== {livro.Título} ======");
        Console.WriteLine("Autor: " + livro.Autor);
        Console.WriteLine("ISBN: " + livro.ISBN);
        Console.WriteLine("Ano de Publicação: " + livro.AnoPublicacao);
        Console.WriteLine("Género: " + livro.Genero);
        if (livro.Disponivel)
        {
            Console.WriteLine("O livro está disponível");
        }
        else
        {
            Console.WriteLine("O livro não está disponível");
        }
        Console.WriteLine("=============================");
    }

    // ----------------- 2. Pesquisar livro ------------------

    private static void PesquisarLivro()
    {
        Console.WriteLine("\n====== 2. Pesquisar Livro ======\n");

        Console.WriteLine("Qual é o título do livro que quer pesquisar?\n");
        string pesquisa = Console.ReadLine();

        bool encontrado = false;

        foreach(Livro livro in livros)
        {
            if (livro.Título.Contains(pesquisa, StringComparison.OrdinalIgnoreCase))
            {
                LivroInfo(livro);
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("\nNão foi encontrado nenhum livro com o título indicado.");
        }
    }

    // ----------------- 3. Adicionar livros -----------------

    private static void AdicionarLivro()
    {
        Console.WriteLine("\n====== 3. Adicionar Livro ======\n");
        //titulo, autor, isbn, ano de publicaçao, genero
        Console.Write("Título: ");
        string titulo = Console.ReadLine();
        Console.Write("Autor: ");
        string autor = Console.ReadLine();
        Console.Write("ISBN: ");
        string isbn = Console.ReadLine();
        Console.Write("Ano de Publicação: ");
        int anoPublicacao = int.Parse(Console.ReadLine());
        Console.Write("Género: ");
        string genero = Console.ReadLine();

        Livro livroNovo = new Livro
        {
            Título = titulo,
            Autor = autor,
            ISBN = isbn,
            AnoPublicacao = anoPublicacao,
            Genero = genero,
            Disponivel = true
        };

        File.AppendAllText(ficheiroLivros, livroNovo.Título+"|"+livroNovo.Autor+"|"+livroNovo.ISBN+"|"+livroNovo.AnoPublicacao+"|"+livroNovo.Genero+"|"+livroNovo.Disponivel+Environment.NewLine);
        livros.Add(livroNovo);

    }

    // ----------------- 4. Requisitar livro -----------------

    private static void RequisitarLivro()
    {
        //to-do
    }

    // ----------------- 5. Devolver livro -----------------

    private static void DevolverLivro()
    {
        //to-do
    }
    

    // ----------------- 6. Remover livro -----------------

    private static void RemoverLivro()
    {
        Console.WriteLine("\n====== 6. Remover Livro ======\n");

        Console.Write("\nInsira o ISBN do livro que deseja remover: ");
        string isbnRemover = Console.ReadLine();

        Livro livroEncontrado = null;

        foreach (Livro livro in livros)
        {
            if(isbnRemover.Equals(livro.ISBN, StringComparison.OrdinalIgnoreCase))
            {
                livroEncontrado = livro;
                break;
            }
        }

        if (livroEncontrado == null)
        {
            Console.WriteLine("\nNão existe nenhum livro com o ISBN indicado.");
        }
        else
        {
            Console.Write($"\nDeseja remover {livroEncontrado.Título}, de {livroEncontrado.Autor}? (s/n): ");
            char resposta = char.Parse(Console.ReadLine());
            if (resposta == 's')
            {
                livros.Remove(livroEncontrado);
                Console.WriteLine($"\n{livroEncontrado.Título}, de {livroEncontrado.Autor} foi removido.");
            }
        }
    }

    // --------------------------------------------------------
    // --------------------- Utilizadores ---------------------
    // --------------------------------------------------------

    // ----------------- 7. Adicionar utilizador -----------------

    private static void CarregarUtilizadores()
    {
        if (!File.Exists(ficheiroUtilizadores))
        {
            File.Create(ficheiroUtilizadores);
        }

        string[] linhas = File.ReadAllLines(ficheiroUtilizadores);
        foreach (string linha in linhas)
        {
            string[] dados = linha.Split('|');
            Utilizador utilizadorNovo = new Utilizador
            {
                NumeroCartaoBiblioteca = dados[0],
                Nome = dados[1]
            };
            utilizadores.Add(utilizadorNovo);
        }
    }

    private static void AdicionarUtilizador()
    {
        Console.WriteLine("\n====== 7. Adicionar utilizador ======\n");

        Console.Write("Insira o nome do utilizador: ");
        string nomeUtilizador = Console.ReadLine();
        string numeroCartaoBiblioteca = GerarNumeroCartaoBiblioteca();

        Utilizador novoUtilizador = new Utilizador()
        {
            NumeroCartaoBiblioteca = numeroCartaoBiblioteca,
            Nome = nomeUtilizador
        };

        utilizadores.Add(novoUtilizador);
        File.AppendAllText(ficheiroUtilizadores, novoUtilizador.NumeroCartaoBiblioteca + "|" + novoUtilizador.Nome + Environment.NewLine);
        Console.WriteLine("\nO utilizador foi adicionado.");
    }

    private static string GerarNumeroCartaoBiblioteca()
    {
        if(utilizadores.Count == 0)
        {
            return "000000001";
        }
        else
        {
            string numeroUltimoUtilizador = utilizadores[utilizadores.Count() - 1].NumeroCartaoBiblioteca;
            return (int.Parse(numeroUltimoUtilizador)+1).ToString("D9");
        }
    }

    // ----------------- 8. Pesquisar utilizador -----------------

    private static void PesquisarUtilizador()
    {
        //to-do
    }

    // ----------------- 9. Remover utilizador -----------------

    private static void RemoverUtilizador()
    {
        //to-do
    }

    // ----------------- 10. Listar utilizador -----------------

    private static void ListarUtilizador()
    {
        //to-do
    }

}