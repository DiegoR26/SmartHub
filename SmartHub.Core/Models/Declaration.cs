using SmartHub.Core.Models.Enums;

namespace SmartHub.Core.Models
{
    public class Declaration
    {
        public int Id { get; set; }
        public required DeclarationType Type { get; set; }
        public required DateTime Competence { get; set; }
        public DeclarationSituations Situation {  get; set; } = DeclarationSituations.Aberta;
        public bool IsActive { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public Declaration()
        {
        }
    }


}
