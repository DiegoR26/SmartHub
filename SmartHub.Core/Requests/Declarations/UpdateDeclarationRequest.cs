using SmartHub.Core.Models;
using SmartHub.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartHub.Core.Requests.Declarations
{
    public class UpdateDeclarationRequest : Request
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tipo de Declaração Inválida")]
        public required DeclarationType Type { get; set; }

        [Required(ErrorMessage = "Competência Inválida")]
        public required DateTime Competence { get; set; }

        [Required(ErrorMessage = "Atividade Inválida")]
        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "Situação Inválida")]
        public DeclarationSituations Situation { get; set; } = DeclarationSituations.Aberta;


    }
}
