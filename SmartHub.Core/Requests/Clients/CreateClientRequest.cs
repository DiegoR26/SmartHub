using SmartHub.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartHub.Core.Requests.Clients
{
    //Flunt ou FluentValidation: bibliotecas de validação para pesquisar no futuro e eliminar as anotações em cima dos atributos

    public class CreateClientRequest : Request
    {
        [Required(ErrorMessage = "Código de Empresa inválido")]
        [Display(Name = "Código no Sistema")]
        public string Cod { get; set; } = string.Empty;

        [Required(ErrorMessage ="Nome inválido")]
        [MaxLength(60, ErrorMessage = "O nome deve conter até 60 caracteres")]
        [Display(Name = "Nome da Empresa")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tributação Inválida")]
        [Display(Name = "Tributação")]
        public TaxationType Taxation { get; set; } = TaxationType.Presumido;

        [Required(ErrorMessage = "CNPJ Inválido")]
        [Length(14, 14, ErrorMessage = "CNPJ precisa conter 14 digitos")]
        [Display(Name ="CNPJ")]
        public string CNPJ { get; set; } = string.Empty;

        [Display(Name = "Inscrição Municipal")]
        public string IM { get; set; } = string.Empty;

        [Display(Name = "Inscrição Estadual")]
        public string IE { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cidade Inválida")]
        [Display(Name = "Cidade")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "UF Inválida")]
        [Display(Name = "Estado")]
        public CountryType Country { get; set; } = CountryType.RS;

        [Display(Name = "Senha da Prefeitura")]
        public string DecPassword { get; set; } = string.Empty;

        [Display(Name = "Observações")]
        public string Observations { get; set; } = string.Empty;

        [Display(Name = "Perfil de Acesso ao Sefaz")]
        public string SefazAccess { get; set; } = string.Empty;

        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Usuário Inválido")]
        [Display(Name = "Usuário")]
        public string UserId { get; set; } = string.Empty;
    }
}
