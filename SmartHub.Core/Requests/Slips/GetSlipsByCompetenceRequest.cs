namespace SmartHub.Core.Requests.Slips
{
    public class GetSlipsByCompetenceRequest : Request
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
