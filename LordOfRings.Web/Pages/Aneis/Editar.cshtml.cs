using LordOfRings.App.DTOs;
using LordOfRings.Domain.Enums;
using LordOfRings.Web.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LordOfRings.Web.Pages.Aneis;

public class EditarModel : PageModel
{
    private readonly AnelService _anelService;
    private readonly ILogger<EditarModel> _logger;

    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public AnelDto Anel { get; set; } = new();
    
    public SelectList Portadores { get; set; }

    public EditarModel(AnelService anelService, ILogger<EditarModel> logger)
    {
        _anelService = anelService;
        _logger = logger;
        Portadores = new SelectList(Enum.GetNames(typeof(Portador)));
    }

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            var anel = await _anelService.ObterPorId(Id);
            if (anel == null)
            {
                TempData["Error"] = "Anel não encontrado.";
                return RedirectToPage("./Index");
            }

            Anel = anel;
            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao obter anel para edição");
            TempData["Error"] = "Erro ao carregar o anel. Tente novamente mais tarde.";
            return RedirectToPage("./Index");
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        try
        {
            await _anelService.Atualizar(Anel);
            TempData["Success"] = "Anel atualizado com sucesso!";
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar anel");
            ModelState.AddModelError(string.Empty, "Erro ao atualizar o anel. Tente novamente mais tarde.");
            return Page();
        }
    }
}