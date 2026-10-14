using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Loja loja = new Loja();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n1 - Listar videojogos");
            Console.WriteLine("2 - Adicionar videojogo");
            Console.WriteLine("3 - Vender videojogo");
            Console.WriteLine("4 - Consultar valor do stock");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    loja.MetodoNove();
                    break;

                case "2":
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();

                    Console.Write("Plataforma: ");
                    string plataforma = Console.ReadLine();

                    Console.Write("Preço: ");
                    if (!double.TryParse(Console.ReadLine(), out double preco))
                    {
                        Console.WriteLine("Preço inválido.");
                        break;
                    }

                    Console.Write("Stock: ");
                    if (!int.TryParse(Console.ReadLine(), out int stock) || stock < 0)
                    {
                        Console.WriteLine("Stock inválido.");
                        break;
                    }

                    loja.MetodoCinco(
                        new Videojogo(nome, plataforma, preco, stock));

                    Console.WriteLine("Videojogo adicionado.");
                    break;

                case "3":
                    Console.Write("Nome do videojogo: ");
                    string nomeVenda = Console.ReadLine();

                    Videojogo jogo = loja.MetodoSete(nomeVenda);

                    if (jogo == null)
                    {
                        Console.WriteLine("Videojogo não encontrado.");
                        break;
                    }

                    Console.Write("Quantidade: ");
                    if (!int.TryParse(Console.ReadLine(), out int quantidade))
                    {
                        Console.WriteLine("Quantidade inválida.");
                        break;
                    }

                    if (jogo.MetodoUm(quantidade))
                    {
                        loja.MetodoSeis();
                        Console.WriteLine("Venda realizada.");
                    }
                    else
                    {
                        Console.WriteLine("Não foi possível realizar a venda.");
                    }
                    break;

                case "4":
                    Console.WriteLine(
                        $"Valor total do stock: {loja.MetodoOito():F2} €");
                    break;

                case "0":
                    loja.MetodoSeis();
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}