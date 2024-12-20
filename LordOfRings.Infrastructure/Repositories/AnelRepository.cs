using LordOfRings.App.Interfaces;
using LordOfRings.Domain.Entities;
using LordOfRings.Domain.Enums;
using LordOfRings.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LordOfRings.Infrastructure.Repositories;

public class AnelRepository : IAnelRepository
{
    private readonly AnelDbContext _context;

    public AnelRepository(AnelDbContext context)
    {
        _context = context;
    }

    public async Task<Anel> ObterPorId(Guid id)
    {
        return await _context.Aneis.FindAsync(id);
    }

    public async Task<List<Anel>> ObterTodos()
    {
        return await _context.Aneis.ToListAsync();
    }

    public async Task<List<Anel>> ObterPorPortador(Portador portador)
    {
        return await _context.Aneis
            .Where(a => a.Portador == portador)
            .ToListAsync();
    }

    public async Task<Anel> Adicionar(Anel anel)
    {
        await _context.Aneis.AddAsync(anel);
        await _context.SaveChangesAsync();
        return anel;
    }

    public async Task Atualizar(Anel anel)
    {
        _context.Aneis.Update(anel);
        await _context.SaveChangesAsync();
    }

    public async Task Remover(Guid id)
    {
        var anel = await ObterPorId(id);
        if (anel != null)
        {
            _context.Aneis.Remove(anel);
            await _context.SaveChangesAsync();
        }
    }
}