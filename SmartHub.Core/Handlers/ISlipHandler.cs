using SmartHub.Core.Models;
using SmartHub.Core.Requests.Slips;
using SmartHub.Core.Responses;

namespace SmartHub.Core.Handlers
{
    public interface ISlipHandler
    {
        Task<Response<Slip?>> CreateAsync(CreateSlipRequest request);
        Task<Response<Slip?>> UpdateAsync(UpdateSlipRequest request);
        Task<Response<Slip?>> DeleteAsync(DeleteSlipRequest request);
        Task<Response<Slip?>> GetByIdAsync(GetSlipByIdRequest request);
        Task<Response<List<Slip>?>> GetAllAsync(GetAllSlipsRequest request);
        Task<Response<List<Slip>?>> GetByCompetenceAsync(GetSlipsByCompetenceRequest request);
    }
}
