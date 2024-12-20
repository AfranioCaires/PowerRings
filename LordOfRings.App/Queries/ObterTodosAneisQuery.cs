using AutoMapper;
using LordOfRings.App.Common;
using LordOfRings.App.DTOs;
using LordOfRings.App.Interfaces;
using MediatR;

namespace LordOfRings.App.Queries;

public class ObterTodosAneisQuery : IRequest<Result<List<AnelDto>>>
{
}

public class ObterTodosAneisQueryHandler : IRequestHandler<ObterTodosAneisQuery, Result<List<AnelDto>>>
{
    private readonly IAnelRepository _repository;
    private readonly IMapper _mapper;

    public ObterTodosAneisQueryHandler(IAnelRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<AnelDto>>> Handle(ObterTodosAneisQuery request, CancellationToken cancellationToken)
    {
        var aneis = await _repository.ObterTodos();
        return Result<List<AnelDto>>.Success(_mapper.Map<List<AnelDto>>(aneis));
    }
}