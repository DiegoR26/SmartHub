using SmartHub.Core.Models;
using SmartHub.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartHub.Core.Requests.Associations
{
    public class UpdateAssociationRequest : Request
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tipo de Declaração Inválida")]
        public required DeclarationType Type { get; set; }

        [Required(ErrorMessage = "Cliente Inválido")]
        public Client Client { get; set; }

    }
}
