namespace SmartHub.Core.Requests.Declarations
{
    public class GetDeclarationsByCompetenceRequest : Request
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

