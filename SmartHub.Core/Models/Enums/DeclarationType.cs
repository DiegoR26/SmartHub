using System.ComponentModel;

namespace SmartHub.Core.Models.Enums
{
    public enum DeclarationType
    {
        [Description("Dec. Prefeitura")]
        DecISSQN = 1,

        [Description("SPED IPI ICMS")]
        SPED_ICMS = 2,

        [Description("GIA ICMS")]
        GIA_ICMS = 3,

        [Description("GIA ST")]
        GIA_ST = 4,

        [Description("PGDAS Simples")]
        PGDAS = 5,

        [Description("Destda SEDIF")]
        Sedif = 6,

        [Description("SPED Contribuições")]
        SPED_PISCOFINS = 7,

        [Description("EFD Reinf")]
        Reinf = 8,

        [Description("SINTEGRA")]
        Sintegra = 9

    }
}
