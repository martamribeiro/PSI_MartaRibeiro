using System;

class Program
{
    // --------------------- Variáveis ---------------------

    public static List<Livro> livros = new List<Livro>();

    // ---------------------- Métodos ----------------------

    static void Main(string[] args)
    {
        
        int opcao;

        do{

            // --------------------- Cabeçalho ---------------------

            Console.WriteLine("\n====== Gestor de Biblioteca ======\n");
            Console.WriteLine("1. Listar livros");
            Console.WriteLine("2. Pesquisar livro");
            Console.WriteLine("3. Adicionar livro");
            Console.WriteLine("4. Requesitar livro");
            Console.WriteLine("5. Devolver livro");
            Console.WriteLine("6. Remover livro");
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
                    break;
                case 3:
                    // Adicionar livro
                    AdicionarLivro();
                    break;
                case 4:
                    // Requisitar livro
                    break;
                case 5:
                    // Devolver livro
                    break;
                case 6:
                    // Remover livro
                    break;
                case 0:
                    // Sair
                    break;
                default:
                    // Outras opções
                    break;
            }

        } while (opcao != 0);
    }

    // ------------------ 1. Listar livros ------------------

    private static void ListarLivros()
    {
        Console.WriteLine("====== 1. Listar Livros ======");

        if (livros.Count == 0)
        {
            Console.WriteLine("\nNão existem livros catalogados.");
        }
        else
        {
            foreach (Livro livro in livros)
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
        }

    }

    // ----------------- 2. Pesquisar livro ------------------

    private static void PesquisarLivro()
    {
        Console.WriteLine("====== 2. Pesquisar Livro ======\n");


    }

    // ----------------- 3. Adicionar livros -----------------

    private static void AdicionarLivro()
    {
        Console.WriteLine("====== 3. Adicionar Livro ======\n");
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

        livros.Add(livroNovo);

    }
}