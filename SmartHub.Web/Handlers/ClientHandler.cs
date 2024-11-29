using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Clients;
using SmartHub.Core.Responses;
using System.Net.Http.Json;

namespace SmartHub.Web.Handlers
{
    public class ClientHandler(IHttpClientFactory httpClientFactory) : IClientHandler
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);

        public async Task<Response<Client?>> CreateAsync(CreateClientRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("v1/clients", request);

            var responseContent = await result.Content.ReadAsStringAsync();
            Console.WriteLine($"Response Content: {responseContent}");

            return await result.Content.ReadFromJsonAsync<Response<Client?>>() ?? new Response<Client?>(null, 400, "Falha ao cadastrar cliente");
        }

        public async Task<Response<Client?>> DeleteAsync(DeleteClientRequest request)
        {
            var result = await _httpClient.DeleteAsync($"v1/clients/{request.Id}");

            return await result.Content.ReadFromJsonAsync<Response<Client?>>() ?? new Response<Client?>(null, 400, "Falha ao excluir cliente");
        }

        public async Task<Response<List<Client>?>> GetAllAsync(GetAllClientsRequest request)
        {
            return await _httpClient.GetFromJsonAsync<Response<List<Client>?>>($"v1/clients") ?? new Response<List<Client>?> (null, 400, "Falha ao encontrar cliente");
        }

        public async Task<Response<Client?>> GetByIdAsync(GetClientByIdRequest request)
        {
            return await _httpClient.GetFromJsonAsync<Response<Client?>>($"v1/clients/{request.Id}") ?? new Response<Client?>(null, 400, "Falha ao encontrar cliente");
        }

        public async Task<Response<Client?>> UpdateAsync(UpdateClientRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"v1/clients/{request.Id}", request);

            return await result.Content.ReadFromJsonAsync<Response<Client?>>() ?? new Response<Client?>(null, 400, "Falha ao atualizar cliente");
        }
    }
}
