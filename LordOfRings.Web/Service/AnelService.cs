using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using LordOfRings.App.Common;
using LordOfRings.App.DTOs;

namespace LordOfRings.Web.Service;

public class AnelService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<AnelService> _logger;
    private readonly JsonSerializerOptions _jsonOptions;

    public AnelService(IHttpClientFactory clientFactory, ILogger<AnelService> logger)
    {
        _httpClient = clientFactory.CreateClient("API");
        _logger = logger;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        };
    }

    public async Task<List<AnelDto>> ObterTodos()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/aneis");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<List<AnelDto>>>(content, _jsonOptions);
            return result?.Data ?? new List<AnelDto>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao obter anéis");
            throw;
        }
    }

    public async Task<AnelDto> ObterPorId(Guid id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/aneis/{id}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorResult = JsonSerializer.Deserialize<Result<AnelDto>>(content, _jsonOptions);
                throw new HttpRequestException(errorResult?.Error ?? "Erro ao obter o anel");
            }

            // Deserialize directly to AnelDto since the API returns unwrapped data
            var anel = JsonSerializer.Deserialize<AnelDto>(content, _jsonOptions);
            if (anel == null)
            {
                throw new HttpRequestException("Anel não encontrado");
            }

            return anel;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao obter anel por ID: {Id}", id);
            throw;
        }
    }

    public async Task<AnelDto> Criar(AnelDto anel)
    {
        var content = new StringContent(
            JsonSerializer.Serialize(anel, _jsonOptions),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync("api/aneis", content);
        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Result<AnelDto>>(responseContent, _jsonOptions);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(result?.Error ?? "Erro desconhecido ao criar o anel");
        }

        return result?.Data;
    }

    public async Task<AnelDto> Atualizar(AnelDto anel)
{
    var content = new StringContent(
        JsonSerializer.Serialize(anel, _jsonOptions),
        Encoding.UTF8,
        "application/json");

    var response = await _httpClient.PutAsync("api/aneis", content);
    var responseContent = await response.Content.ReadAsStringAsync();
    var result = JsonSerializer.Deserialize<Result<AnelDto>>(responseContent, _jsonOptions);

    if (!response.IsSuccessStatusCode)
    {
        throw new HttpRequestException(result?.Error ?? "Erro desconhecido ao atualizar o anel");
    }

    return result?.Data;
}

    public async Task Deletar(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/aneis/{id}");
        response.EnsureSuccessStatusCode();
    }
}