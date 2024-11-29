using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Declarations;
using SmartHub.Core.Responses;
using System.Net.Http.Json;

namespace SmartHub.Web.Handlers
{
    public class DeclarationHandler(IHttpClientFactory httpClientFactory) : IDeclarationHandler
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);

        public async Task<Response<Declaration?>> CreateAsync(CreateDeclarationRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("v1/declarations", request);

            return await result.Content.ReadFromJsonAsync<Response<Declaration?>>() ?? new Response<Declaration?>(null, 400, "Falha ao cadastrar declaração");
        }

        public async Task<Response<Declaration?>> DeleteAsync(DeleteDeclarationRequest request)
        {
            var result = await _httpClient.DeleteAsync($"v1/declarations/{request.Id}");

            return await result.Content.ReadFromJsonAsync<Response<Declaration?>>() ?? new Response<Declaration?>(null, 400, "Falha ao excluir declaração");
        }

        public async Task<Response<List<Declaration>?>> GetAllAsync(GetAllDeclarationsRequest request)
        {
            return await _httpClient.GetFromJsonAsync<Response<List<Declaration>?>>($"v1/declarations") ?? new Response<List<Declaration>?>(null, 400, "Falha ao encontrar declarações");
        }

        public async Task<Response<List<Declaration>?>> GetByCompetenceAsync(GetDeclarationsByCompetenceRequest request)
        {
            return await _httpClient.GetFromJsonAsync<Response<List<Declaration>?>>($"v1/declarations/competence") ?? new Response<List<Declaration>?>(null, 400, "Falha ao encontrar declarações");
        }

        public async Task<Response<Declaration?>> GetByIdAsync(GetDeclarationByIdRequest request)
        {
            return await _httpClient.GetFromJsonAsync<Response<Declaration?>>($"v1/declarations/{request.Id}") ?? new Response<Declaration?>(null, 400, "Falha ao encontrar declaração");
        }

        public async Task<Response<Declaration?>> UpdateAsync(UpdateDeclarationRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"v1/declarations/{request.Id}", request);

            return await result.Content.ReadFromJsonAsync<Response<Declaration?>>() ?? new Response<Declaration?>(null, 400, "Falha ao atualizar declaração");
        }
    }
}
