using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Responses;

namespace SmartHub.Core.Requests.Clients
{
    public class DeleteClientRequest : Request
    {
        public int Id { get; set; }

    }
}
