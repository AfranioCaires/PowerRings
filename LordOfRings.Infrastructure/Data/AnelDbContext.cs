namespace LordOfRings.Infrastructure.Data;

using LordOfRings.Domain.Entities;
using LordOfRings.Domain.Enums;
using Microsoft.EntityFrameworkCore;

public class AnelDbContext : DbContext
{
    public AnelDbContext(DbContextOptions<AnelDbContext> options) : base(options)
    {
    }

    public DbSet<Anel> Aneis { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Poder).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Portador).IsRequired();
            entity.Property(e => e.ForjadoPor).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Imagem).IsRequired().HasMaxLength(500);
        });
    }
}