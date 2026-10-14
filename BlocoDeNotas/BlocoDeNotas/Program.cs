using System;

class Program
{
    //Ficheiro de notas
    const string ficheiroNotas = "notas.txt";

    //Ficheiro de backup de notas
    const string ficheiroNotasBackup = "notas_backup.txt";

    static void Main(string[] args)
    {
        if (!File.Exists(ficheiroNotas))
        {
            File.Create(ficheiroNotas).Close();
        }

        //Menu
        int opçao;
        do
        {
            Console.WriteLine("===== BLOCO DE NOTAS =====");
            Console.WriteLine("\n1. Escrever uma nova nota");
            Console.WriteLine("2. Consultar todas as notas");
            Console.WriteLine("3. Apagar todas as notas");
            Console.WriteLine("4. Criar cópia de segurança");
            Console.WriteLine("0. Sair");
            Console.Write("\nEscolha uma opção: ");

            opçao = int.Parse(Console.ReadLine());

            //Chamar as funcionalidades dependendo da opção
            switch (opçao)
            {
                case 1:
                    AdicionarNota();
                    break;
                case 2:
                    ConsultarNotas();
                    break;
                case 3:
                    ApagarNotas();
                    break;
                case 4:
                    CriarBackup();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Essa opção não existe.");
                    break;
            }
        } while (opçao!=0);
    }

    //Adicionar nota
    private static void AdicionarNota()
    {
        Console.WriteLine("Digite a sua nota");
        string nota = Console.ReadLine();
        File.AppendAllText(ficheiroNotas, nota + Environment.NewLine);
        Console.WriteLine("Nota guardada com sucesso!");
    }

    //Consultar notas
    private static void ConsultarNotas()
    {
        string conteudo = File.ReadAllText(ficheiroNotas);

        //File.ReadAllText(ficheiroNotas)==""
        if (string.IsNullOrWhiteSpace(conteudo)){
            Console.WriteLine("Não existe conteúdo no bloco de notas.");
        }
        else
        {
            Console.WriteLine("Notas salvas:");
            Console.WriteLine(conteudo);
        }

        

    }

    //Apagar notas
    private static void ApagarNotas()
    {
        Console.WriteLine("Tem a certeza que pretende apagar todas as notas? (s/n)");
        string resposta = Console.ReadLine();

        if (resposta.Equals("s", StringComparison.OrdinalIgnoreCase))
        {
            File.WriteAllText(ficheiroNotas,"");
            Console.WriteLine("Todas as notas foram apagadas.");
        }
        else
        {
            Console.WriteLine("Operação cancelada.");
        }
    }

    //Criar backup
    private static void CriarBackup()
    {
        if (!File.Exists(ficheiroNotasBackup))
        {
            File.Create(ficheiroNotasBackup).Close();
        }

        File.Copy(ficheiroNotas, ficheiroNotasBackup, true);
    }
}