using SmartHub.Core.Models.Enums;

namespace SmartHub.Core.Models
{
    public class Client
    {
        /* --- Dados Basicos --- */
        public int Id { get; set; }
        public string Cod { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public TaxationType Taxation { get; set; } = TaxationType.Presumido;
        public string CNPJ { get; set; } = string.Empty;
        public string? IM { get; set; }
        public string? IE { get; set; } 
        public string City { get; set; } = string.Empty;
        public CountryType Country { get; set; } = CountryType.RS;
        public string? DecPassword { get; set; }
        public bool IsActive { get; set; } = true;
        public string UserId { get; set; } = string.Empty;

        /* --- Extras --- */
        public string? Observations { get; set; }
        public string? SefazAccess { get; set; }
        public string? Email { get; set; }

        /* --- Declarações --- */
        public ICollection<Declaration> Declarations { get; set; } = new List<Declaration>();

        /* --- Guias --- */
        public ICollection<Slip> Slips { get; set; } = new List<Slip>();

        public Client()
        {
        }
    }
}
