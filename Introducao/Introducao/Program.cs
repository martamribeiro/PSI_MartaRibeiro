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

        Console.Write("Nome: ");
        string nomeUtilizador = Console.ReadLine();
        Console.WriteLine("Olá "+nomeUtilizador);
    }
}