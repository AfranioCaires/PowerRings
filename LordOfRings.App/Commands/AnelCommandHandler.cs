using AutoMapper;
using LordOfRings.App.Common;
using LordOfRings.App.DTOs;
using LordOfRings.App.Interfaces;
using LordOfRings.Domain.Entities;
using LordOfRings.Domain.Enums;
using MediatR;

namespace LordOfRings.App.Commands;

public class AnelCommandHandler :
    IRequestHandler<CriarAnelCommand, Result<AnelDto>>,
    IRequestHandler<AtualizarAnelCommand, Result<AnelDto>>,
    IRequestHandler<DeletarAnelCommand, Result<bool>>
{
    private readonly IAnelRepository _repository;
    private readonly IMapper _mapper;

    public AnelCommandHandler(IAnelRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<AnelDto>> Handle(CriarAnelCommand request, CancellationToken cancellationToken)
    {
        if (!Enum.TryParse<Portador>(request.Portador, true, out var portador))
            return Result<AnelDto>.Failure("Tipo de portador inválido. Use: Elfo, Anao, Homem ou Sauron");

        var aneisExistentes = await _repository.ObterPorPortador(portador);
        var imagem = string.IsNullOrEmpty(request.Imagem) 
            ? "https://cinepop.com.br/wp-content/uploads/2022/01/o-senhor-dos-aneis-5.jpg"
            : request.Imagem;
        if (!ValidarLimiteAneis(portador, aneisExistentes.Count))
            return Result<AnelDto>.Failure($"Limite de anéis excedido para {portador}");

        var anel = new Anel(
            request.Nome,
            request.Poder,
            portador,
            request.ForjadoPor,
            imagem
        );

        await _repository.Adicionar(anel);
        return Result<AnelDto>.Success(_mapper.Map<AnelDto>(anel));
    }

    public async Task<Result<AnelDto>> Handle(AtualizarAnelCommand request, CancellationToken cancellationToken)
    {
        var anel = await _repository.ObterPorId(request.Id);

        if (anel == null)
            return Result<AnelDto>.Failure("Anel não encontrado");
        
        if (!Enum.TryParse<Portador>(request.Portador, true, out var portador))
            return Result<AnelDto>.Failure("Tipo de portador inválido. Use: Elfo, Anao, Homem ou Sauron");

        var aneisExistentes = await _repository.ObterPorPortador(portador);
        
        var imagem = string.IsNullOrEmpty(request.Imagem) 
            ? "https://cinepop.com.br/wp-content/uploads/2022/01/o-senhor-dos-aneis-5.jpg"
            : request.Imagem;
        
        if (!ValidarLimiteAneis(portador, aneisExistentes.Count))
            return Result<AnelDto>.Failure($"Limite de anéis excedido para {portador}");

        anel.Atualizar(
            request.Nome,
            request.Poder,
            portador,
            request.ForjadoPor,
            imagem
        );

        await _repository.Atualizar(anel);

        return Result<AnelDto>.Success(_mapper.Map<AnelDto>(anel));
    }

    public async Task<Result<bool>> Handle(DeletarAnelCommand request, CancellationToken cancellationToken)
    {
        var anel = await _repository.ObterPorId(request.Id);

        if (anel == null)
            return Result<bool>.Failure("Anel não encontrado");

        await _repository.Remover(request.Id);

        return Result<bool>.Success(true);
    }

    private bool ValidarLimiteAneis(Portador portador, int quantidade)
    {
        return portador switch
        {
            Portador.Elfo => quantidade < 3,
            Portador.Anao => quantidade < 7,
            Portador.Homem => quantidade < 9,
            Portador.Sauron => quantidade < 1,
            _ => false
        };
    }

    private bool IsValidPortador(Portador portador)
    {
        return Enum.IsDefined(typeof(Portador), portador);
    }
}