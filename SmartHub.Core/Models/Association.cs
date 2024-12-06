using SmartHub.Core.Models.Enums;

namespace SmartHub.Core.Models
{
    public class Association
    {
        public int Id { get; set; }
        public required DeclarationType Type { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
