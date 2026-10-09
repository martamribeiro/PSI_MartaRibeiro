using System;

/// <summary>
/// Representa um livro existente na biblioteca.
/// 
/// Esta classe contém toda a informação necessária
/// para identificar e caracterizar um livro.
/// </summary>
class Livro
{
    /// <summary>
    /// Título do livro.
    /// </summary>
    public string Título { get; set; }

    /// <summary>
    /// Nome do autor do livro.
    /// </summary>
    public string Autor { get; set; }

    /// <summary>
    /// ISBN do livro.
    /// 
    /// O ISBN é utilizado para identificar um livro
    /// de forma única.
    /// </summary>
    public string ISBN { get; set; }

    /// <summary>
    /// Ano em que o livro foi publicado.
    /// </summary>
    public int AnoPublicacao { get; set; }

    /// <summary>
    /// Género literário do livro.
    /// </summary>
    public string Genero { get; set; }

    /// <summary>
    /// Indica se o livro está disponível para ser requisitado.
    /// 
    /// true  = disponível
    /// false = requisitado
    /// </summary>
    public bool Disponivel { get; set; }

    /// <summary>
    /// Utilizador que tem o livro requisitado.
    ///
    /// Se o livro não estiver requisitado, esta propriedade
    /// tem o valor null.
    /// </summary>
    public Utilizador UtilizadorRequisitado { get; set; }

    /// <summary>
    /// Construtor da classe Livro.
    ///
    /// Inicializa um novo livro como disponível e sem
    /// qualquer utilizador associado à sua requisição.
    /// </summary>
    public Livro()
    {
        // Por defeito, um livro acabado de criar está disponível.
        Disponivel = true;

        // Inicialmente, o livro não está associado
        // a nenhum utilizador.
        UtilizadorRequisitado = null;
    }

}