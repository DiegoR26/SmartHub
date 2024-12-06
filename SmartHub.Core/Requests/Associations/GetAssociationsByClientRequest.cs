using SmartHub.Core.Models;

namespace SmartHub.Core.Requests.Associations
{
    public class GetAssociationsByClientRequest : Request
    {
        public Client Client { get; set; }
    }
}

