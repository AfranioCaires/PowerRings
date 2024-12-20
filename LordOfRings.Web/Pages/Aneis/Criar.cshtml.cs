using LordOfRings.App.DTOs;
using LordOfRings.Domain.Enums;
using LordOfRings.Web.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LordOfRings.Web.Pages.Aneis;

public class CriarModel : PageModel
{
    private readonly AnelService _anelService;
    private readonly ILogger<CriarModel> _logger;

    [BindProperty] public AnelDto Anel { get; set; } = new();

    public SelectList Portadores { get; set; }

    public CriarModel(AnelService anelService, ILogger<CriarModel> logger)
    {
        _anelService = anelService;
        _logger = logger;
        Portadores = new SelectList(Enum.GetNames(typeof(Portador)));
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        try
        {
            var result = await _anelService.Criar(Anel);
            if (result != null)
            {
                TempData["Success"] = "Anel criado com sucesso!";
                return RedirectToPage("./Index");
            }

            return Page();
        }
        catch (HttpRequestException ex)
        {
            ModelState.AddModelError(string.Empty, "Erro ao criar o anel. Tente novamente mais tarde.");
            return Page();
        }
    }
}
