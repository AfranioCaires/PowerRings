using System.ComponentModel.DataAnnotations;
using LordOfRings.Domain.Enums;

namespace LordOfRings.App.DTOs;

public class AnelDto
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O Nome é obrigatório")]
    [StringLength(100, ErrorMessage = "O Nome não pode ter mais que 100 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O Poder é obrigatório")]
    public string Poder { get; set; }

    [Required(ErrorMessage = "O Portador é obrigatório")]
    public Portador Portador { get; set; }

    [Required(ErrorMessage = "O Forjador é obrigatório")]
    public string ForjadoPor { get; set; }

    [Url(ErrorMessage = "A URL da imagem deve ser válida")]
    public string? Imagem { get; set; }
}