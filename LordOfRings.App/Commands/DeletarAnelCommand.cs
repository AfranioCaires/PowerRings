using LordOfRings.App.Common;
using MediatR;

namespace LordOfRings.App.Commands;

public class DeletarAnelCommand : IRequest<Result<bool>>
{
    public Guid Id { get; set; }
}