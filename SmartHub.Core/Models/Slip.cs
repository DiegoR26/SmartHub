using SmartHub.Core.Models.Enums;

namespace SmartHub.Core.Models
{
    public class Slip
    {
        public int Id { get; set; }
        public required SlipType Type { get; set; }
        public required DateTime Competence { get; set; }
        public SlipSituations Situation { get; set; } = SlipSituations.Aberta;
        public double Value { get; set; }
        public bool IsActive { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public Slip()
        {
        }
    }
}
