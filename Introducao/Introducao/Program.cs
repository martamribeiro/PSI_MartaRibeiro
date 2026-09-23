using System; //livraria nativa do c#, com todas as classes e métodos que vamos usar

class Program //classe deste script
{
    static void Main(string[] args) //permite o código correr
    {
        //Console.WriteLine("5+3"); //a imprimir uma string
        //Console.WriteLine(5+3); //a imprimir um int
        //string mensagemBoasVindas = "Olá, bem vindo,";
        //Console.WriteLine(mensagemBoasVindas);
        //string nome = "Marta";
        //Console.WriteLine(mensagemBoasVindas+" "+nome+".");
        //Console.WriteLine("Olá "+nomeUtilizador+" tens " + idadeUtilizador+" anos.");
        //Console.WriteLine("Olá {0} tens {1} anos.",nomeUtilizador,idadeUtilizador);

        Console.Write("Nome: ");
        string nomeUtilizador = Console.ReadLine();
        Console.Write("Idade: ");
        int idadeUtilizador = int.Parse(Console.ReadLine());
        Console.Write("Altura (m): ");
        double alturaUtilizador = double.Parse(Console.ReadLine());
        Console.Write("Peso (kg): ");
        double pesoUtilizador = double.Parse(Console.ReadLine());
        Console.WriteLine($"Olá {nomeUtilizador} tens {idadeUtilizador} anos.");

        double imc = pesoUtilizador / Math.Pow(alturaUtilizador,2);
        imc = Math.Round(imc, 2);

        Console.WriteLine($"O seu IMC (Indíce de Massa Corporal) é {imc}");
    }
}