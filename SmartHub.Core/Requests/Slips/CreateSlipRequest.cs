using SmartHub.Core.Models;
using SmartHub.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartHub.Core.Requests.Slips
{
    public class CreateSlipRequest : Request
    {
        [Required(ErrorMessage = "Tipo de Guia Inválida")]
        public required SlipType Type { get; set; }

        [Required(ErrorMessage = "Competência Inválida")]
        public required DateTime Competence { get; set; }

        public double Value { get; set; }

        [Required(ErrorMessage = "Cliente Inválido")]
        public Client Client { get; set; }
    }
}
