using System;
using System.Collections.Generic;
using System.Text;

class Loja
{
    public List<Videojogo> Jogos { get; set; }
    private const string CaminhoFicheiro = "videojogos.txt";

    public Loja()
    {
        Jogos = new List<Videojogo>();
        MetodoQuatro();
    }

    public void MetodoCinco(Videojogo jogo)
    {
        Jogos.Add(jogo);
        MetodoSeis();
    }

    public Videojogo MetodoSete(string nome)
    {
        foreach (Videojogo jogo in Jogos)
        {
            if (jogo.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
            {
                return jogo;
            }
        }

        return null;
    }

    public double MetodoOito()
    {
        double total = 0;

        foreach (Videojogo jogo in Jogos)
        {
            total += jogo.Preco * jogo.Stock;
        }

        return total;
    }

    public void MetodoNove()
    {
        foreach (Videojogo jogo in Jogos)
        {
            jogo.MetodoTres();
            Console.WriteLine("--------------------");
        }
    }

    public void MetodoSeis()
    {
        List<string> linhas = new List<string>();

        foreach (Videojogo jogo in Jogos)
        {
            linhas.Add(jogo.MetodoDois());
        }

        File.WriteAllLines(CaminhoFicheiro, linhas);
    }

    public void MetodoQuatro()
    {
        if (!File.Exists(CaminhoFicheiro))
        {
            File.WriteAllText(CaminhoFicheiro, "");
            return;
        }

        string[] linhas = File.ReadAllLines(CaminhoFicheiro);

        foreach (string linha in linhas)
        {
            string[] dados = linha.Split('|');

            if (dados.Length == 4 &&
                double.TryParse(dados[2], out double preco) &&
                int.TryParse(dados[3], out int stock))
            {
                Videojogo jogo = new Videojogo(
                    dados[0], dados[1], preco, stock);

                Jogos.Add(jogo);
            }
        }
    }
}