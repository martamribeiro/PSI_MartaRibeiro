using System;

/// <summary>
/// Representa um utilizador da biblioteca.
/// 
/// Cada utilizador possui um número de cartão único
/// e um nome.
/// </summary>
class Utilizador
{
    /// <summary>
    /// Número do cartão da biblioteca que identifica o utilizador.
    /// </summary>
    public string NumeroCartaoBiblioteca { get; set; }

    /// <summary>
    /// Nome do utilizador da biblioteca.
    /// </summary>
    public string Nome { get; set; }

    public List<Livro> LivrosRequisitados { get; set; } // limite de dois livros

    public Utilizador()
    {
        LivrosRequisitados = new List<Livro>();
    }
}