using System;
using System.Globalization;
using System.IO;

/// <summary>
/// Classe principal da aplicação de gestão da biblioteca.
/// 
/// Esta classe contém:
/// - o menu principal;
/// - as listas de livros e utilizadores;
/// - os métodos para gerir livros;
/// - os métodos para gerir utilizadores;
/// - os métodos para ler e escrever nos ficheiros.
/// </summary>
class Program
{
    // ==========================================================
    // ===================== VARIÁVEIS ==========================
    // ==========================================================

    /// <summary>
    /// Lista que contém todos os livros carregados para a memória.
    /// </summary>
    public static List<Livro> livros = new List<Livro>();

    /// <summary>
    /// Lista que contém todos os utilizadores carregados para a memória.
    /// </summary>
    public static List<Utilizador> utilizadores = new List<Utilizador>();

    /// <summary>
    /// Nome do ficheiro onde são guardados os livros.
    /// </summary>
    public const string ficheiroLivros = "livros.txt";

    /// <summary>
    /// Nome do ficheiro onde são guardados os utilizadores.
    /// </summary>
    public const string ficheiroUtilizadores = "utilizadores.txt";

    // ==========================================================
    // ========================= MAIN ===========================
    // ==========================================================

    /// <summary>
    /// Método principal da aplicação.
    /// 
    /// É o primeiro método executado quando o programa começa.
    /// 
    /// Primeiro são carregados os livros e os utilizadores
    /// existentes nos respetivos ficheiros.
    /// 
    /// De seguida, é apresentado o menu principal até o
    /// utilizador escolher a opção 0 - Sair.
    /// </summary>
    /// 
    /// <param name="args">
    /// Argumentos que podem ser enviados para o programa
    /// através da linha de comandos.
    /// </param>
    static void Main(string[] args)
    {

        // Carregar os dados guardados nos ficheiros.
        CarregarLivros();
        CarregarUtilizadores();
        
        int opcao;

        // O ciclo do...while permite apresentar o menu
        // repetidamente até o utilizador escolher 0.
        do
        {

            // ==================================================
            // ==================== CABEÇALHO ===================
            // ==================================================

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
            Console.WriteLine("8. Pesquisar utilizador");
            Console.WriteLine("9. Remover utilizador");
            Console.WriteLine("10. Listar utilizador");
            
            Console.WriteLine("====== Outros ======");
            
            Console.WriteLine("0. Sair\n");
            
            Console.Write("Selecione uma opção: ");

            // Ler a opção escolhida pelo utilizador.
            // int.Parse converte o texto introduzido para
            // um número inteiro.
            opcao = int.Parse(Console.ReadLine());

            // ==================================================
            // ===================== OPÇÕES =====================
            // ==================================================

            // O switch permite executar uma ação diferente
            // dependendo da opção escolhida.
            switch (opcao)
            {
                case 1:
                    // Listar todos os livros.
                    ListarLivros();
                    break;
                case 2:
                    // Pesquisar um livro pelo título.
                    PesquisarLivro();
                    break;
                case 3:
                    // Adicionar um novo livro.
                    AdicionarLivro();
                    break;
                case 4:
                    // Requisitar um livro.
                    // Funcionalidade ainda por implementar.
                    RequisitarLivro();
                    break;
                case 5:
                    // Devolver um livro.
                    // Funcionalidade ainda por implementar.
                    DevolverLivro();
                    break;
                case 6:
                    // Remover um livro.
                    RemoverLivro();
                    break;
                case 7:
                    // Adicionar um novo utilizador.
                    AdicionarUtilizador();
                    break;
                case 8:
                    // Pesquisar um utilizador.
                    PesquisarUtilizador();
                    break;
                case 9:
                    // Remover um utilizador.
                    RemoverUtilizador();
                    break;
                case 10:
                    // Listar todos os utilizadores.
                    ListarUtilizador();
                    break;
                case 0:
                    // O programa termina quando o utilizador
                    // escolhe a opção 0.
                    break;
                default:
                    // Caso seja introduzida uma opção que
                    // não existe no menu.
                    Console.WriteLine("A opção não existe.");
                    break;
            }

        // O menu continua a ser apresentado enquanto
        // a opção escolhida for diferente de 0.
        } while (opcao != 0);
    }

    // --------------------------------------------------
    // --------------------- Livros ---------------------
    // --------------------------------------------------

    /// <summary>
    /// Carrega os livros existentes no ficheiro livros.txt.
    /// 
    /// Cada linha do ficheiro representa um livro.
    /// Os dados estão separados pelo carácter '|'.
    /// 
    /// Exemplo:
    /// Harry Potter|J.K. Rowling|9781234567890|1997|Fantasia|True
    /// </summary>
    private static void CarregarLivros()
    {
        // Verificar se o ficheiro existe.
        if (!File.Exists(ficheiroLivros))
        {
            // Se não existir, criar o ficheiro.
            File.Create(ficheiroLivros);
            return;
        }

        // Ler todas as linhas do ficheiro.
        string[] linhas = File.ReadAllLines(ficheiroLivros);

        // Percorrer todas as linhas.
        foreach (string linha in linhas)
        {
            // Separar os diferentes campos utilizando '|'.
            //
            // Exemplo:
            // "1984|George Orwell|123|1949|Distopia|True"
            //
            // fica dividido em:
            // dados[0] -> 1984
            // dados[1] -> George Orwell
            // dados[2] -> 123
            // dados[3] -> 1949
            // dados[4] -> Distopia
            // dados[5] -> True
            string[] dados = linha.Split('|');

            // Criar um novo objeto Livro.
            Livro livroNovo = new Livro
            {
                Título = dados[0],
                Autor = dados[1],
                ISBN = dados[2],

                // Converter o ano de texto para inteiro.
                AnoPublicacao = int.Parse(dados[3]),

                Genero = dados[4],

                // Converter o texto "True"/"False"
                // para um valor booleano.
                Disponivel = bool.Parse(dados[5])
            };

            // Adicionar o livro à lista.
            livros.Add(livroNovo);
        }
    }

    // ==========================================================
    // =================== 1. LISTAR LIVROS ====================
    // ==========================================================

    /// <summary>
    /// Apresenta todos os livros existentes na biblioteca.
    /// 
    /// Se não existirem livros, é apresentada uma mensagem
    /// a informar o utilizador.
    /// </summary>
    private static void ListarLivros()
    {
        Console.WriteLine("\n====== 1. Listar Livros ======");

        // Verificar se a lista está vazia.
        if (livros.Count == 0)
        {
            Console.WriteLine("\nNão existem livros catalogados.");
        }
        else
        {
            // Percorrer todos os livros da lista.
            foreach (Livro livro in livros)
            {
                // Mostrar a informação de cada livro.
                LivroInfo(livro);
            }
        }
    }

    /// <summary>
    /// Apresenta no ecrã a informação de um determinado livro.
    /// </summary>
    /// 
    /// <param name="livro">
    /// Livro cuja informação será apresentada.
    /// </param>
    public static void LivroInfo(Livro livro)
    {
        Console.WriteLine($"\n====== {livro.Título} ======");

        Console.WriteLine("Autor: " + livro.Autor);

        Console.WriteLine("ISBN: " + livro.ISBN);

        Console.WriteLine(
            "Ano de Publicação: " + livro.AnoPublicacao);

        Console.WriteLine("Género: " + livro.Genero);

        // Verificar se o livro está disponível.
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

    // ==========================================================
    // ================= 2. PESQUISAR LIVRO ====================
    // ==========================================================

    /// <summary>
    /// Permite pesquisar livros através do título.
    /// 
    /// A pesquisa não diferencia letras maiúsculas de
    /// letras minúsculas.
    /// </summary>
    private static void PesquisarLivro()
    {
        Console.WriteLine("\n====== 2. Pesquisar Livro ======\n");

        Console.WriteLine(
            "Qual é o título do livro que quer pesquisar?\n");

        // Ler o texto introduzido pelo utilizador.
        string pesquisa = Console.ReadLine();

        // Variável utilizada para saber se foi encontrado
        // pelo menos um livro.
        bool encontrado = false;

        // Percorrer todos os livros.
        foreach (Livro livro in livros)
        {
            // Verificar se o título contém o texto pesquisado.
            //
            // OrdinalIgnoreCase faz com que a pesquisa
            // ignore diferenças entre maiúsculas e minúsculas.
            if (livro.Título.Contains(
                pesquisa,
                StringComparison.OrdinalIgnoreCase))
            {
                // Apresentar o livro encontrado.
                LivroInfo(livro);

                // Indicar que foi encontrado pelo menos
                // um resultado.
                encontrado = true;
            }
        }

        // Se nenhum livro foi encontrado...
        if (!encontrado)
        {
            Console.WriteLine(
                "\nNão foi encontrado nenhum livro " +
                "com o título indicado.");
        }
    }

    // ==========================================================
    // ================= 3. ADICIONAR LIVRO ====================
    // ==========================================================

    /// <summary>
    /// Permite ao utilizador adicionar um novo livro.
    /// 
    /// O novo livro é:
    /// 1. criado na memória;
    /// 2. guardado no ficheiro;
    /// 3. adicionado à lista de livros.
    /// </summary>
    private static void AdicionarLivro()
    {
        Console.WriteLine("\n====== 3. Adicionar Livro ======\n");

        // Pedir os dados do livro ao utilizador.

        Console.Write("Título: ");
        string titulo = Console.ReadLine();

        Console.Write("Autor: ");
        string autor = Console.ReadLine();

        Console.Write("ISBN: ");
        string isbn = Console.ReadLine();

        Console.Write("Ano de Publicação: ");

        // Converter o ano introduzido para inteiro.
        int anoPublicacao = int.Parse(Console.ReadLine());

        Console.Write("Género: ");
        string genero = Console.ReadLine();


        // Criar um novo objeto Livro.
        Livro livroNovo = new Livro
        {
            Título = titulo,
            Autor = autor,
            ISBN = isbn,
            AnoPublicacao = anoPublicacao,
            Genero = genero,

            // Um livro acabado de adicionar está disponível.
            Disponivel = true,
            UtilizadorRequisitado = null
        };

        livros.Add(livroNovo);

        // Guardar o livro no ficheiro.
        GuardarLivro();
    }

    /// <summary>
    /// Guarda todos os livros no ficheiro livros.txt.
    ///
    /// Cada livro é convertido numa linha de texto com os
    /// seus dados separados pelo carácter '|'.
    ///
    /// Também é guardado o número do cartão do utilizador
    /// que requisitou o livro.
    /// </summary>
    private static void GuardarLivro()
    {
        // Criar uma lista para armazenar as linhas
        // que serão escritas no ficheiro.
        List<string> linhas = new List<string>();

        // Percorrer todos os livros existentes na biblioteca.
        foreach (Livro livro in livros)
        {
            // Por defeito, o livro não tem utilizador associado.
            string numeroCartaoBiblioteca = "0";

            // Se existir um utilizador associado ao livro,
            // guardar o número do respetivo cartão.
            if (livro.UtilizadorRequisitado != null)
            {
                numeroCartaoBiblioteca =
                    livro.UtilizadorRequisitado.NumeroCartaoBiblioteca;
            }

            // Construir a linha com os dados do livro.
            // O último campo identifica o utilizador associado.
            linhas.Add(
                livro.Título + "|" +
                livro.Autor + "|" +
                livro.ISBN + "|" +
                livro.AnoPublicacao + "|" +
                livro.Genero + "|" +
                livro.Disponivel + "|" +
                numeroCartaoBiblioteca
            );
        }

        // Substituir o conteúdo do ficheiro pelas linhas atuais.
        File.WriteAllLines(ficheiroLivros, linhas);
    }

    // ==========================================================
    // ================= 4. REQUISITAR LIVRO ===================
    // ==========================================================

    /// <summary>
    /// Permite requisitar um livro.
    /// </summary>
    private static void RequisitarLivro()
    {
        Console.WriteLine("\n====== 4. Requisitar Livro ======\n");

        Console.Write("Insira o ISBN do livro a requisitar: ");
        string isbn = Console.ReadLine();

        Livro livroARequisitar = null;

        // Percorrer todos os livros à procura do ISBN indicado.
        foreach (Livro livro in livros)
        {
            // Comparar o ISBN introduzido com o ISBN do livro.
            if (isbn.Equals(
            livro.ISBN,
            StringComparison.OrdinalIgnoreCase))
            {
                // Só é possível requisitar um livro disponível.
                if (livro.Disponivel)
                {
                    // Guardar a referência ao livro encontrado.
                    livroARequisitar = livro;

                    // Terminar o ciclo porque o livro já foi encontrado.
                    break;
                }
                else
                {
                    // Impedir uma nova requisição de um livro
                    // que já se encontra requisitado.
                    Console.WriteLine("O livro não está disponível.");

                    // Terminar o método sem continuar a requisição.
                    return;
                }
            }

        }

        if (livroARequisitar == null)
        {
            Console.WriteLine("Não existe nenhum livro com o isbn indicado.");
        }

        Console.Write("Insira o número do cartão do utilizador: ");
        string numeroCartao = Console.ReadLine();

        Utilizador utilizadorEncontrado = null;

        // Percorrer a lista de utilizadores para encontrar
        // aquele que corresponde ao número de cartão introduzido.
        foreach (Utilizador utilizador in utilizadores)
        {
            if (numeroCartao.Equals(
            utilizador.NumeroCartaoBiblioteca,
            StringComparison.OrdinalIgnoreCase))
            {
                // Verificar quantos livros o utilizador tem requisitados.
                if (utilizador.LivrosRequisitados.Count < 2)
                {
                    // O utilizador existe e ainda pode requisitar livros.
                    utilizadorEncontrado = utilizador;

                    // Terminar o ciclo porque já foi encontrado.
                    break;
                }
                else
                {
                    // O limite de dois livros já foi atingido.
                    Console.WriteLine(
                        "O utilizador já atingiu o limite de livros.");

                    // Interromper a operação de requisição.
                    return;
                }
            }

        }

        if (utilizadorEncontrado == null)
        {
            Console.WriteLine("O utilizador indicado não existe.");
        }

        // Alterar o estado do livro para indicar que
        // deixou de estar disponível.
        livroARequisitar.Disponivel = false;

        // Associar o livro ao utilizador que o requisitou.
        livroARequisitar.UtilizadorRequisitado = utilizadorEncontrado;

        // Adicionar o livro à lista de livros requisitados
        // desse utilizador.
        utilizadorEncontrado.LivrosRequisitados.Add(livroARequisitar);

        // Guardar as alterações nos dois ficheiros para que
        // a informação das requisições fique persistente.
        GuardarLivro();
        GuardarUtilizador();

        Console.WriteLine($"O livro {livroARequisitar.Título} de {livroARequisitar.Autor} foi requisitado por {utilizadorEncontrado.Nome}, com o nº {utilizadorEncontrado.NumeroCartaoBiblioteca}.");
    }

    // ==========================================================
    // ================= 5. DEVOLVER LIVRO =====================
    // ==========================================================

    /// <summary>
    /// Permite devolver um livro.
    /// </summary>
    private static void DevolverLivro()
    {
        Console.WriteLine("\n====== 5. Devolver Livro ======\n");

        Console.Write("\nInsira o ISBN do livro a devolver: ");
        string isbnRemover = Console.ReadLine();

        Livro livroEncontrado = null;

        foreach (Livro livro in livros)
        {
            //se o livro existe
            if(isbnRemover.Equals(livro.ISBN, StringComparison.OrdinalIgnoreCase)){
                livroEncontrado = livro;
                //se foi requisitado
                if(livro.Disponivel == true)
                {
                    Console.WriteLine("O livro não está requisitado");
                    return;
                }
                break;
            }
        }

        if (livroEncontrado == null)
        {
            Console.WriteLine("Não existe nenhum livro com o isbn indicado.");
            return;
        }

        //utilizador que tem o livro
        Utilizador utilizadorComLivro = livroEncontrado.UtilizadorRequisitado;

        Console.Write("\nInsira o número do cartão da biblioteca do utilizador: ");
        string numeroUtilizador = Console.ReadLine();

        Utilizador utilizadorEncontrado = null;

        foreach(Utilizador utilizador in utilizadores)
        {
            //se o utilizador existe
            if(numeroUtilizador.Equals(utilizador.NumeroCartaoBiblioteca, StringComparison.OrdinalIgnoreCase))
            {
                utilizadorEncontrado = utilizador;
                //se este é o utilizador que tem o livro
                if (utilizador.NumeroCartaoBiblioteca != utilizadorComLivro.NumeroCartaoBiblioteca) {
                    Console.WriteLine("Este utilizador não tem o livro indicado.");
                    return;
                }
                break;
            }
        }

        if(utilizadorEncontrado == null)
        {
            Console.WriteLine("O utilizador com o número de cartão indicado não existe.");
            return;
        }

        utilizadorEncontrado.LivrosRequisitados.Remove(livroEncontrado);
        livroEncontrado.Disponivel = true;
        livroEncontrado.UtilizadorRequisitado = null;

        GuardarLivro();
        GuardarUtilizador();
    }


    // ==========================================================
    // ================== 6. REMOVER LIVRO =====================
    // ==========================================================

    /// <summary>
    /// Remove um livro da biblioteca através do seu ISBN.
    /// 
    /// Antes da remoção é pedida uma confirmação ao utilizador.
    /// </summary>
    private static void RemoverLivro()
    {
        Console.WriteLine("\n====== 6. Remover Livro ======\n");

        Console.Write(
            "\nInsira o ISBN do livro que deseja remover: ");

        // Ler o ISBN introduzido.
        string isbnRemover = Console.ReadLine();

        // Variável que irá guardar o livro encontrado.
        Livro livroEncontrado = null;

        // Índice do livro dentro da lista.
        int indiceLivro = -1;


        // Percorrer a lista através de um ciclo for.
        for (int i = 0; i < livros.Count; i++)
        {
            // Comparar o ISBN introduzido com o ISBN
            // de cada livro.
            if (isbnRemover.Equals(
                livros[i].ISBN,
                StringComparison.OrdinalIgnoreCase))
            {
                // Guardar o livro encontrado.
                livroEncontrado = livros[i];

                // Guardar a posição do livro na lista.
                indiceLivro = i;

                // Como já encontramos o livro,
                // podemos terminar o ciclo.
                break;
            }
        }


        // Verificar se o livro foi encontrado.
        if (livroEncontrado == null)
        {
            Console.WriteLine(
                "\nNão existe nenhum livro " +
                "com o ISBN indicado.");
        }
        else
        {
            // Pedir confirmação antes de eliminar.
            Console.Write(
                $"\nDeseja remover " +
                $"{livroEncontrado.Título}, " +
                $"de {livroEncontrado.Autor}? (s/n): ");

            char resposta = char.Parse(Console.ReadLine());


            // Verificar se o utilizador respondeu "s".
            if (resposta == 's')
            {
                // Remover o livro da lista.
                livros.Remove(livroEncontrado);


                // Ler novamente o conteúdo do ficheiro.
                string[] linhasLivros =
                    File.ReadAllLines(ficheiroLivros);


                // Criar uma nova lista com as linhas do ficheiro.
                List<string> novasLinhas =
                    new List<string>(linhasLivros);


                // Remover da lista a linha correspondente
                // ao livro eliminado.
                novasLinhas.RemoveAt(indiceLivro);


                // Escrever novamente os dados no ficheiro.
                File.WriteAllLines(
                    ficheiroLivros,
                    linhasLivros);


                Console.WriteLine(
                    $"\n{livroEncontrado.Título}, " +
                    $"de {livroEncontrado.Autor} foi removido.");
            }
        }
    }

    // --------------------------------------------------------
    // --------------------- Utilizadores ---------------------
    // --------------------------------------------------------

    /// <summary>
    /// Carrega os utilizadores existentes no ficheiro
    /// utilizadores.txt.
    /// 
    /// Cada linha contém:
    /// NúmeroCartaoBiblioteca|Nome
    /// </summary>
    private static void CarregarUtilizadores()
    {
        // Verificar se o ficheiro existe.
        if (!File.Exists(ficheiroUtilizadores))
        {
            // Criar o ficheiro se este ainda não existir.
            File.Create(ficheiroUtilizadores);
            return;
        }

        // Ler todas as linhas do ficheiro.
        string[] linhas =
            File.ReadAllLines(ficheiroUtilizadores);


        // Percorrer todas as linhas.
        foreach (string linha in linhas)
        {
            // Separar os campos utilizando '|'.
            string[] dados = linha.Split('|');


            // Criar um novo objeto Utilizador.
            Utilizador utilizadorNovo = new Utilizador
            {
                NumeroCartaoBiblioteca = dados[0],
                Nome = dados[1]
            };


            // Adicionar o utilizador à lista.
            utilizadores.Add(utilizadorNovo);
        }
    }

    // ==========================================================
    // ============== 7. ADICIONAR UTILIZADOR ===================
    // ==========================================================

    /// <summary>
    /// Cria um novo utilizador.
    /// 
    /// O número do cartão é gerado automaticamente pelo programa.
    /// Depois, o utilizador é guardado na lista e no ficheiro.
    /// </summary>
    private static void AdicionarUtilizador()
    {
        Console.WriteLine(
            "\n====== 7. Adicionar utilizador ======\n");


        // Pedir o nome do novo utilizador.
        Console.Write(
            "Insira o nome do utilizador: ");

        string nomeUtilizador =
            Console.ReadLine();


        // Gerar automaticamente o número do cartão.
        string numeroCartaoBiblioteca =
            GerarNumeroCartaoBiblioteca();


        // Criar o novo objeto Utilizador.
        Utilizador novoUtilizador = new Utilizador()
        {
            NumeroCartaoBiblioteca =
                numeroCartaoBiblioteca,

            Nome = nomeUtilizador,
            LivrosRequisitados = new List<Livro>()
        };


        // Adicionar o utilizador à lista.
        utilizadores.Add(novoUtilizador);


        // Guardar o utilizador no ficheiro.
        GuardarUtilizador();

        Console.WriteLine("\nO utilizador foi adicionado.");
    }

    /// <summary>
    /// Guarda todos os utilizadores no ficheiro utilizadores.txt.
    ///
    /// Para cada utilizador, são guardados o número do cartão,
    /// o nome e os ISBN dos livros requisitados.
    ///
    /// O formato permite registar até dois livros por utilizador.
    /// O valor "0" representa uma posição sem livro associado.
    /// </summary>
    private static void GuardarUtilizador()
    {
        // Lista que irá conter as linhas do ficheiro.
        List<string> linhas = new List<string>();

        // Percorrer todos os utilizadores registados.
        foreach (Utilizador utilizador in utilizadores)
        {
            // Por defeito, não existem livros associados
            // à primeira nem à segunda posição.
            string isbn1 = "0", isbn2 = "0";

            // Se existir um livro requisitado, guardar o seu ISBN.
            if (utilizador.LivrosRequisitados.Count == 1)
            {
                isbn1 = utilizador.LivrosRequisitados[0].ISBN;
            }
            // Se existirem dois livros, guardar os dois ISBN.
            else if (utilizador.LivrosRequisitados.Count == 2)
            {
                isbn1 = utilizador.LivrosRequisitados[0].ISBN;
                isbn2 = utilizador.LivrosRequisitados[1].ISBN;
            }

            // Construir a linha com os dados do utilizador.
            linhas.Add(
                utilizador.NumeroCartaoBiblioteca + "|" +
                utilizador.Nome + "|" +
                isbn1 + "|" +
                isbn2
            );
        }

        // Atualizar o ficheiro com todos os utilizadores.
        File.WriteAllLines(ficheiroUtilizadores, linhas);
    }

    /// <summary>
    /// Gera um novo número de cartão da biblioteca.
    /// 
    /// Se ainda não existir nenhum utilizador,
    /// o primeiro número será 000000001.
    /// 
    /// Caso já existam utilizadores, o número será
    /// incrementado a partir do último utilizador.
    /// </summary>
    /// 
    /// <returns>
    /// Uma string com o novo número de cartão.
    /// </returns>
    private static string GerarNumeroCartaoBiblioteca()
    {
        // Se não existirem utilizadores...
        if (utilizadores.Count == 0)
        {
            // O primeiro cartão será 000000001.
            return "000000001";
        }
        else
        {
            // Obter o número do último utilizador.
            string numeroUltimoUtilizador =
                utilizadores[
                    utilizadores.Count() - 1
                ].NumeroCartaoBiblioteca;


            // Converter o número para inteiro,
            // adicionar 1 e voltar a converter para texto.
            //
            // D9 garante que o número terá sempre
            // 9 algarismos.
            return (
                int.Parse(numeroUltimoUtilizador) + 1
            ).ToString("D9");
        }
    }

    // ==========================================================
    // ============== 8. PESQUISAR UTILIZADOR ===================
    // ==========================================================

    /// <summary>
    /// Permite pesquisar utilizadores através do nome.
    /// 
    /// A pesquisa não diferencia letras maiúsculas
    /// de letras minúsculas.
    /// </summary>
    private static void PesquisarUtilizador()
    {
        Console.WriteLine(
            "\n====== 8. Pesquisar Utilizador ======\n");


        Console.WriteLine(
            "Qual é o nome do utilizador " +
            "que quer pesquisar?\n");


        // Ler o nome a pesquisar.
        string pesquisa = Console.ReadLine();


        // Variável utilizada para saber se foi
        // encontrado algum utilizador.
        bool encontrado = false;


        // Percorrer todos os utilizadores.
        foreach (Utilizador utilizador in utilizadores)
        {
            // Verificar se o nome contém o texto pesquisado.
            if (utilizador.Nome.Contains(
                pesquisa,
                StringComparison.OrdinalIgnoreCase))
            {
                // Apresentar os dados do utilizador.
                UtilizadorInfo(utilizador);

                // Indicar que foi encontrado.
                encontrado = true;
            }
        }


        // Caso nenhum utilizador tenha sido encontrado.
        if (!encontrado)
        {
            Console.WriteLine(
                "\nNão foi encontrado nenhum utilizador " +
                "com o nome indicado.");
        }
    }

    /// <summary>
    /// Apresenta no ecrã a informação de um utilizador.
    /// </summary>
    /// 
    /// <param name="utilizador">
    /// Utilizador cuja informação será apresentada.
    /// </param>
    public static void UtilizadorInfo(
        Utilizador utilizador)
    {
        Console.WriteLine("\n========================");

        Console.WriteLine(
            "Nome: " + utilizador.Nome);

        Console.WriteLine(
            "Número do Cartão da Biblioteca: " +
            utilizador.NumeroCartaoBiblioteca);

        // Se existir exatamente um livro requisitado,
        // apresentar os seus dados.
        if (utilizador.LivrosRequisitados.Count == 1)
        {
            Console.WriteLine(
            $"O livro {utilizador.LivrosRequisitados[0].Título} " +
            $"de {utilizador.LivrosRequisitados[0].Autor} está requisitado.");
        }
        // Se existirem dois livros requisitados,
        // apresentar a informação de ambos.
        else if (utilizador.LivrosRequisitados.Count == 2)
        {
            Console.WriteLine(
            $"O livro {utilizador.LivrosRequisitados[0].Título} " +
            $"de {utilizador.LivrosRequisitados[0].Autor} está requisitado.");

            Console.WriteLine(
            $"O livro {utilizador.LivrosRequisitados[1].Título} " +
            $"de {utilizador.LivrosRequisitados[1].Autor} está requisitado.");

        }
        // Se a lista estiver vazia, o utilizador não tem livros requisitados.
        else
        {
            Console.WriteLine(
            "O utilizador não requisitou qualquer livro.");
        }

        Console.WriteLine("\n========================");
    }

    // ==========================================================
    // ================ 9. REMOVER UTILIZADOR ===================
    // ==========================================================


    /// <summary>
    /// Remove um utilizador através do seu número de cartão.
    /// 
    /// Antes da remoção é pedida uma confirmação.
    /// </summary>
    private static void RemoverUtilizador()
    {
        Console.WriteLine(
            "\n====== 9. Remover Utilizador ======\n");


        Console.WriteLine(
            "Insira o número do cartão " +
            "do utilizador que deseja remover.");


        // Ler o número do cartão.
        string numeroCartao = Console.ReadLine();


        // Variável que irá guardar o utilizador encontrado.
        Utilizador utilizadorEncontrado = null;


        // Índice do utilizador dentro da lista.
        int indiceUtilizador = -1;


        // Procurar o utilizador na lista.
        for (int i = 0; i < utilizadores.Count; i++)
        {
            // Comparar o número introduzido com o número
            // de cada utilizador.
            if (numeroCartao.Equals(
                utilizadores[i].NumeroCartaoBiblioteca,
                StringComparison.OrdinalIgnoreCase))
            {
                // Guardar o utilizador encontrado.
                utilizadorEncontrado =
                    utilizadores[i];


                // Guardar a posição do utilizador.
                indiceUtilizador = i;


                // Parar o ciclo porque já encontramos
                // o utilizador.
                break;
            }
        }


        // Verificar se o utilizador foi encontrado.
        if (utilizadorEncontrado == null)
        {
            Console.WriteLine(
                "Não existe nenhum utilizador " +
                "com o número de cartão indicado.");
        }
        else
        {
            // Pedir confirmação antes de remover.
            Console.Write(
                "Deseja remover o utilizador " +
                utilizadorEncontrado.Nome +
                " com o número de cartão " +
                utilizadorEncontrado.NumeroCartaoBiblioteca +
                " ? (s/n): ");


            char resposta =
                char.Parse(Console.ReadLine());


            // Aceitar tanto 's' como 'S'.
            if (resposta == 's' || resposta == 'S')
            {
                // Remover o utilizador da lista.
                utilizadores.Remove(utilizadorEncontrado);


                // Ler todas as linhas do ficheiro.
                string[] linhasUtilizadores =
                    File.ReadAllLines(
                        ficheiroUtilizadores);


                // Criar uma nova lista com as linhas.
                List<string> novasLinhas =
                    new List<string>(
                        linhasUtilizadores);


                // Remover a linha correspondente
                // ao utilizador eliminado.
                novasLinhas.RemoveAt(
                    indiceUtilizador);


                // Atualizar o ficheiro.
                File.WriteAllLines(
                    ficheiroUtilizadores,
                    novasLinhas);


                Console.WriteLine(
                    "\nO utilizador " +
                    utilizadorEncontrado.Nome +
                    " com o número de cartão " +
                    utilizadorEncontrado.NumeroCartaoBiblioteca +
                    " foi removido.");
            }
        }
    }

    // ==========================================================
    // ================ 10. LISTAR UTILIZADORES =================
    // ==========================================================

    /// <summary>
    /// Apresenta todos os utilizadores registados na biblioteca.
    /// 
    /// Se não existirem utilizadores, é apresentada
    /// uma mensagem informativa.
    /// </summary>
    private static void ListarUtilizador()
    {
        Console.WriteLine(
            "\n====== 10. Listar Utilizador ======\n");


        // Verificar se existem utilizadores.
        if (utilizadores.Count == 0)
        {
            Console.WriteLine(
                "\nNão existem utilizadores registados.");
        }
        else
        {
            // Percorrer todos os utilizadores.
            foreach (Utilizador utilizador in utilizadores)
            {
                // Apresentar a informação do utilizador.
                UtilizadorInfo(utilizador);
            }
        }
    }
}