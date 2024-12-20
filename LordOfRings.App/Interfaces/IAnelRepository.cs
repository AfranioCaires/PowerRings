using LordOfRings.Domain.Entities;
using LordOfRings.Domain.Enums;

namespace LordOfRings.App.Interfaces;

public interface IAnelRepository
{
    Task<Anel> ObterPorId(Guid id);
    Task<List<Anel>> ObterTodos();
    Task<List<Anel>> ObterPorPortador(Portador portador);
    Task<Anel> Adicionar(Anel anel);
    Task Atualizar(Anel anel);
    Task Remover(Guid id);
}