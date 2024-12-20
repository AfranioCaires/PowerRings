using LordOfRings.App.DTOs;
using LordOfRings.Web.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LordOfRings.Web.Pages.Aneis;

public class IndexModel : PageModel
{
    private readonly AnelService _anelService;
    private readonly ILogger<IndexModel> _logger;

    public List<AnelDto> Aneis { get; set; } = new();

    public IndexModel(AnelService anelService, ILogger<IndexModel> logger)
    {
        _anelService = anelService;
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
        try
        {
            Aneis = await _anelService.ObterTodos();
            _logger.LogInformation("Anéis carregados: {Count}", Aneis?.Count ?? 0);
            foreach (var anel in Aneis)
            {
                _logger.LogInformation("Anel: {Nome}, Portador: {Portador}", anel.Nome, anel.Portador);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao obter anéis");
            TempData["Error"] = "Erro ao carregar os anéis. Tente novamente mais tarde.";
        }
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid id)
    {
        try
        {
            await _anelService.Deletar(id);
            TempData["Success"] = "Anel excluído com sucesso!";
            return RedirectToPage();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao deletar anel");
            TempData["Error"] = "Erro ao excluir o anel. Tente novamente mais tarde.";
            return RedirectToPage();
        }
    }
}