using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Slips;
using SmartHub.Core.Responses;
using System.Net.Http.Json;

namespace SmartHub.Web.Handlers
{
    public class SlipHandler(IHttpClientFactory httpClientFactory) : ISlipHandler
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);

        public async Task<Response<Slip?>> CreateAsync(CreateSlipRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("v1/slips", request);

            return await result.Content.ReadFromJsonAsync<Response<Slip?>>() ?? new Response<Slip?>(null, 400, "Falha ao cadastrar guia");
        }

        public async Task<Response<Slip?>> DeleteAsync(DeleteSlipRequest request)
        {
            var result = await _httpClient.DeleteAsync($"v1/slips/{request.Id}");

            return await result.Content.ReadFromJsonAsync<Response<Slip?>>() ?? new Response<Slip?>(null, 400, "Falha ao excluir guia");
        }

        public async Task<Response<List<Slip>?>> GetAllAsync(GetAllSlipsRequest request)
        {
            return await _httpClient.GetFromJsonAsync<Response<List<Slip>?>>($"v1/slips") ?? new Response<List<Slip>?>(null, 400, "Falha ao encontrar guias");
        }

        public async Task<Response<List<Slip>?>> GetByCompetenceAsync(GetSlipsByCompetenceRequest request)
        {
            return await _httpClient.GetFromJsonAsync<Response<List<Slip>?>>($"v1/slips/competence") ?? new Response<List<Slip>?>(null, 400, "Falha ao encontrar guias");
        }

        public async Task<Response<Slip?>> GetByIdAsync(GetSlipByIdRequest request)
        {
            return await _httpClient.GetFromJsonAsync<Response<Slip?>>($"v1/slips/{request.Id}") ?? new Response<Slip?>(null, 400, "Falha ao encontrar guia");
        }

        public async Task<Response<Slip?>> UpdateAsync(UpdateSlipRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"v1/slips/{request.Id}", request);

            return await result.Content.ReadFromJsonAsync<Response<Slip?>>() ?? new Response<Slip?>(null, 400, "Falha ao atualizar guia");
        }
    }
}
