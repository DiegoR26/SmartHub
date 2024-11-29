using SmartHub.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartHub.Core.Requests.Clients
{
    public class UpdateClientRequest : Request
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Código de Empresa inválido")]
        public string Cod { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nome inválido")]
        [MaxLength(60, ErrorMessage = "O nome deve conter até 60 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tributação Inválida")]
        public TaxationType Taxation { get; set; }

        [Required(ErrorMessage = "CNPJ Inválido")]
        [Length(14, 14, ErrorMessage = "CNPJ precisa conter 14 digitos")]
        public string CNPJ { get; set; } = string.Empty;

        public string IM { get; set; } = string.Empty;
        public string IE { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cidade Inválida")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "UF Inválida")]
        public CountryType Country { get; set; } = CountryType.RS;

        public string DecPassword { get; set; } = string.Empty;
        public string Observations { get; set; } = string.Empty;
        public string SefazAccess { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Atividade Inválida")]
        public bool IsActive { get; set; } = true;
    }
}
