using SmartHub.Core.Models;
using SmartHub.Core.Requests.Declarations;
using SmartHub.Core.Responses;

namespace SmartHub.Core.Handlers
{
    public interface IDeclarationHandler
    {
        Task<Response<Declaration?>> CreateAsync(CreateDeclarationRequest request);
        Task<Response<Declaration?>> UpdateAsync(UpdateDeclarationRequest request);
        Task<Response<Declaration?>> DeleteAsync(DeleteDeclarationRequest request);
        Task<Response<Declaration?>> GetByIdAsync(GetDeclarationByIdRequest request);
        Task<Response<List<Declaration>?>> GetAllAsync(GetAllDeclarationsRequest request);
        Task<Response<List<Declaration>?>> GetByCompetenceAsync(GetDeclarationsByCompetenceRequest request);
    }
}
