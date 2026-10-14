using System;
using System.Collections.Generic;
using System.Text;


class Videojogo
{
    public string Nome { get; set; }
    public string Plataforma { get; set; }
    public double Preco { get; set; }
    public int Stock { get; set; }

    public Videojogo(string nome, string plataforma, double preco, int stock)
    {
        Nome = nome;
        Plataforma = plataforma;
        Preco = preco;
        Stock = stock;
    }

    public bool MetodoUm(int quantidade)
    {
        if (quantidade <= 0)
        {
            return false;
        }

        if (quantidade > Stock)
        {
            return false;
        }

        Stock -= quantidade;
        return true;
    }

    public string MetodoDois()
    {
        return $"{Nome}|{Plataforma}|{Preco}|{Stock}";
    }

    public void MetodoTres()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Plataforma: {Plataforma}");
        Console.WriteLine($"Preço: {Preco:F2} €");
        Console.WriteLine($"Stock: {Stock}");
    }
}