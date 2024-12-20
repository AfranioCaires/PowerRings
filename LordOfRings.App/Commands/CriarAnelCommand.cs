using LordOfRings.App.Common;
using LordOfRings.App.DTOs;
using LordOfRings.Domain.Enums;
using MediatR;

namespace LordOfRings.App.Commands;

public class CriarAnelCommand : IRequest<Result<AnelDto>>
{
    public string Nome { get; set; }
    public string Poder { get; set; }
    public string Portador { get; set; }
    public string ForjadoPor { get; set; }
    public string Imagem { get; set; }
}