using System.ComponentModel.DataAnnotations;

namespace LordOfRings.API.InputModels;

/// <summary>
/// Modelo para criação de um novo Anel de Poder
/// </summary>
public class CriarAnelInputModel
{
    /// <summary>
    /// Nome do anel
    /// </summary>
    /// <example>Narya</example>
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
    public string Nome { get; set; }

    /// <summary>
    /// Poder ou habilidade especial do anel
    /// </summary>
    /// <example>Controle sobre o fogo e capacidade de inspirar outros</example>
    [Required(ErrorMessage = "O poder é obrigatório")]
    [StringLength(500, ErrorMessage = "O poder deve ter no máximo 500 caracteres")]
    public string Poder { get; set; }

    /// <summary>
    /// Portador do anel (Elfo, Anao, Homem ou Sauron)
    /// </summary>
    /// <example>Elfo</example>
    [Required(ErrorMessage = "O portador é obrigatório")]
    public string Portador { get; set; }

    /// <summary>
    /// Nome de quem forjou o anel
    /// </summary>
    /// <example>Celebrimbor</example>
    [Required(ErrorMessage = "O forjador é obrigatório")]
    [StringLength(100, ErrorMessage = "O forjador deve ter no máximo 100 caracteres")]
    public string ForjadoPor { get; set; }

    /// <summary>
    /// URL da imagem do anel
    /// </summary>
    /// <example>https://exemplo.com/imagem-anel.jpg</example>
    [StringLength(500, ErrorMessage = "A URL da imagem deve ter no máximo 500 caracteres")]
    [Url(ErrorMessage = "A URL da imagem deve ser válida")]
    public string? Imagem { get; set; }
}

/// <summary>
/// Modelo para atualização de um Anel de Poder existente
/// </summary>
public class AtualizarAnelInputModel
{
    /// <summary>
    /// Identificador único do anel
    /// </summary>
    /// <example>3fa85f64-5717-4562-b3fc-2c963f66afa6</example>
    [Required(ErrorMessage = "O Id é obrigatório")]
    public Guid Id { get; set; }

    /// <summary>
    /// Nome do anel
    /// </summary>
    /// <example>Narya</example>
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
    public string Nome { get; set; }

    /// <summary>
    /// Poder ou habilidade especial do anel
    /// </summary>
    /// <example>Controle sobre o fogo e capacidade de inspirar outros</example>
    [Required(ErrorMessage = "O poder é obrigatório")]
    [StringLength(500, ErrorMessage = "O poder deve ter no máximo 500 caracteres")]
    public string Poder { get; set; }

    /// <summary>
    /// Portador do anel (Elfo, Anao, Homem ou Sauron)
    /// </summary>
    /// <example>Elfo</example>
    [Required(ErrorMessage = "O portador é obrigatório")]
    public string Portador { get; set; }

    /// <summary>
    /// Nome de quem forjou o anel
    /// </summary>
    /// <example>Celebrimbor</example>
    [Required(ErrorMessage = "O forjador é obrigatório")]
    [StringLength(100, ErrorMessage = "O forjador deve ter no máximo 100 caracteres")]
    public string ForjadoPor { get; set; }

    /// <summary>
    /// URL da imagem do anel
    /// </summary>
    /// <example>https://exemplo.com/imagem-anel.jpg</example>
    [StringLength(500, ErrorMessage = "A URL da imagem deve ter no máximo 500 caracteres")]
    [Url(ErrorMessage = "A URL da imagem deve ser válida")]
    public string? Imagem { get; set; }
}

/// <summary>
/// Modelo para deleção de um Anel de Poder
/// </summary>
public class DeletarAnelInputModel
{
    /// <summary>
    /// Identificador único do anel
    /// </summary>
    /// <example>3fa85f64-5717-4562-b3fc-2c963f66afa6</example>
    [Required(ErrorMessage = "O Id é obrigatório")]
    public Guid Id { get; set; }
}