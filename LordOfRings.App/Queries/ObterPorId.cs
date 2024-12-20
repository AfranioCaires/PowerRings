using AutoMapper;
using LordOfRings.App.Common;
using LordOfRings.App.DTOs;
using LordOfRings.App.Interfaces;
using MediatR;

namespace LordOfRings.App.Queries;

public class ObterAnelPorIdQuery : IRequest<Result<AnelDto>>
{
    public Guid Id { get; set; }

    public ObterAnelPorIdQuery(Guid id)
    {
        Id = id;
    }
}

public class ObterAnelPorIdQueryHandler : IRequestHandler<ObterAnelPorIdQuery, Result<AnelDto>>
{
    private readonly IAnelRepository _repository;
    private readonly IMapper _mapper;

    public ObterAnelPorIdQueryHandler(IAnelRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<AnelDto>> Handle(ObterAnelPorIdQuery request, CancellationToken cancellationToken)
    {
        var anel = await _repository.ObterPorId(request.Id);

        if (anel == null)
            return Result<AnelDto>.Failure("Anel não encontrado");

        return Result<AnelDto>.Success(_mapper.Map<AnelDto>(anel));
    }
}