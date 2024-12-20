using LordOfRings.Domain.Enums;

namespace LordOfRings.Domain.Entities;

public class Anel
{
    public Guid Id { get; set; }
    public string Nome { get; private set; }
    public string Poder { get; private set; }
    public Portador Portador { get; private set; }
    public string ForjadoPor { get; private set; }
    public string Imagem { get; private set; }

    public Anel(string nome, string poder, Portador portador, string forjadoPor, string imagem)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Poder = poder;
        Portador = portador;
        ForjadoPor = forjadoPor;
        Imagem = imagem;
    }

    public void Atualizar(string nome, string poder, Portador portador, string forjadoPor, string imagem)
    {
        Nome = nome;
        Poder = poder;
        Portador = portador;
        ForjadoPor = forjadoPor;
        Imagem = imagem;
    }
}