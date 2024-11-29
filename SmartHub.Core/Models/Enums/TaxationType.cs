using System.ComponentModel;

namespace SmartHub.Core.Models.Enums
{
    public enum TaxationType
    {
        [Description("Lucro Presumido")]
        Presumido = 1,

        [Description("Lucro Real")]
        Real = 2,

        [Description("Simples Nacional")]
        Simples = 3,

        [Description("Outras")]
        Outro = 4
    }
}
