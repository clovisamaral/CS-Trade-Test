using System.ComponentModel;

namespace Application.Entities.Enums
{
    public enum TradeCategoryEnum
    {
        [Description("EXPIRED")]
        Expired = 1,
        [Description("HIGHRISK")]
        Highrisk = 2,
        [Description("MEDIUMRISK")]
        Mediumrisk = 3,
        [Description("PEP")]
        Pep = 4
    }
}
