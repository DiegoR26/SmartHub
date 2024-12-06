using SmartHub.Core.Models;
using SmartHub.Core.Requests.Associations;
using SmartHub.Core.Responses;

namespace SmartHub.Core.Handlers
{
    public interface IAssociationHandler
    {
        Task<Response<Association?>> CreateAsync(CreateAssociationRequest request);
        Task<Response<Association?>> UpdateAsync(UpdateAssociationRequest request);
        Task<Response<Association?>> DeleteAsync(DeleteAssociationRequest request);
        Task<Response<Association?>> GetByIdAsync(GetAssociationByIdRequest request);
        Task<Response<List<Association>?>> GetAllAsync(GetAllAssociationsRequest request);
        Task<Response<List<Association>?>> GetByClientAsync(GetAssociationsByClientRequest request);
    }
}
