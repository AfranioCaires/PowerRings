using LordOfRings.App.Common;
using LordOfRings.App.DTOs;
using LordOfRings.Domain.Enums;
using MediatR;

namespace LordOfRings.App.Commands;

public class AtualizarAnelCommand : IRequest<Result<AnelDto>>
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Poder { get; set; }
    public string Portador { get; set; }
    public string ForjadoPor { get; set; }
    public string Imagem { get; set; }
}