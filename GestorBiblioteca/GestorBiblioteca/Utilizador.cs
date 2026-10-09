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

    /// <summary>
    /// Lista dos livros que o utilizador tem requisitados.
    ///
    /// O programa limita o número de livros requisitados
    /// por cada utilizador a dois.
    /// </summary>
    public List<Livro> LivrosRequisitados { get; set; }

    /// <summary>
    /// Construtor da classe Utilizador.
    ///
    /// Inicializa a lista de livros requisitados vazia,
    /// para que possa receber livros posteriormente.
    /// </summary>
    public Utilizador()
    {
        LivrosRequisitados = new List<Livro>();
    }

}