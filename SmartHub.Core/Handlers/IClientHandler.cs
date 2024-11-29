using SmartHub.Core.Models;
using SmartHub.Core.Requests.Clients;
using SmartHub.Core.Responses;

namespace SmartHub.Core.Handlers
{
    public interface IClientHandler
    {
        Task<Response<Client?>> CreateAsync(CreateClientRequest request);
        Task<Response<Client?>> UpdateAsync(UpdateClientRequest request);
        Task<Response<Client?>> DeleteAsync(DeleteClientRequest request);
        Task<Response<Client?>> GetByIdAsync(GetClientByIdRequest request);
        Task<Response<List<Client>?>> GetAllAsync(GetAllClientsRequest request);

    }
}
