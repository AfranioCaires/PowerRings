using AutoMapper;
using LordOfRings.API.InputModels;
using LordOfRings.App.Commands;
using LordOfRings.App.Common;
using LordOfRings.App.DTOs;
using LordOfRings.App.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LordOfRings.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Tags("Anéis")]
public class AneisController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AneisController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Retorna todos os anéis cadastrados
    /// </summary>
    /// <response code="200">Lista de anéis retornada com sucesso</response>
    [HttpGet]
    [ProducesResponseType(typeof(Result<List<AnelDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObterTodos()
    {
        var resultado = await _mediator.Send(new ObterTodosAneisQuery());
        return Ok(resultado);
    }

    /// <summary>
    /// Retorna um anel específico pelo seu identificador
    /// </summary>
    /// <param name="id">Identificador único do anel</param>
    /// <response code="200">Anel encontrado com sucesso</response>
    /// <response code="404">Anel não encontrado</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Result<AnelDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<AnelDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        var resultado = await _mediator.Send(new ObterAnelPorIdQuery(id));
        
        if (!resultado.IsSuccess)
            return NotFound(resultado);

        return Ok(resultado.Data);
    }

    /// <summary>
    /// Cria um novo anel
    /// </summary>
    /// <response code="201">Anel criado com sucesso</response>
    /// <response code="400">Dados inválidos ou limite de anéis excedido</response>
    [HttpPost]
    [ProducesResponseType(typeof(Result<AnelDto>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Result<AnelDto>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Criar([FromBody] CriarAnelInputModel inputModel)
    {
        var command = new CriarAnelCommand
        {
            Nome = inputModel.Nome,
            Poder = inputModel.Poder,
            Portador = inputModel.Portador,
            ForjadoPor = inputModel.ForjadoPor,
            Imagem = inputModel.Imagem
        };

        var resultado = await _mediator.Send(command);
        
        if (!resultado.IsSuccess)
            return BadRequest(resultado);

        return CreatedAtAction(
            nameof(ObterPorId), 
            new { id = resultado.Data.Id }, 
            resultado.Data);
    }

    /// <summary>
    /// Atualiza um anel existente
    /// </summary>
    /// <response code="200">Anel atualizado com sucesso</response>
    /// <response code="404">Anel não encontrado</response>
    [HttpPut]
    [ProducesResponseType(typeof(Result<AnelDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<AnelDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Atualizar([FromBody] AtualizarAnelInputModel inputModel)
    {
        var command = new AtualizarAnelCommand
        {
            Id = inputModel.Id,
            Nome = inputModel.Nome,
            Poder = inputModel.Poder,
            Portador = inputModel.Portador,
            ForjadoPor = inputModel.ForjadoPor,
            Imagem = inputModel.Imagem
        };

        var resultado = await _mediator.Send(command);
        
        if (!resultado.IsSuccess)
            return NotFound(resultado);

        return Ok(resultado.Data);
    }

    /// <summary>
    /// Remove um anel existente
    /// </summary>
    /// <response code="204">Anel removido com sucesso</response>
    /// <response code="404">Anel não encontrado</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Deletar(Guid id)
    {
        var command = new DeletarAnelCommand { Id = id };
        var resultado = await _mediator.Send(command);
    
        if (!resultado.IsSuccess)
            return NotFound(resultado);

        return NoContent();
    }
}