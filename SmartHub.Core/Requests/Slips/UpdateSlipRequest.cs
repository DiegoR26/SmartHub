using SmartHub.Core.Models;
using SmartHub.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartHub.Core.Requests.Slips
{
    public class UpdateSlipRequest : Request
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tipo de Guia Inválida")]
        public required SlipType Type { get; set; }

        [Required(ErrorMessage = "Competência Inválida")]
        public required DateTime Competence { get; set; }

        public double Value { get; set; }

        [Required(ErrorMessage = "Atividade Inválida")]
        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "Situação Inválida")]
        public SlipSituations Situation { get; set; } = SlipSituations.Aberta;
    }
}
