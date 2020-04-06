using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TariffComparison.Common.Enums
{
    public enum TariffType
    {
        [Description("BasicElectricityTariff")]
        [Display(Name = "Basic")]
        Basic = 1,

        [Description("PackagedTariff")]
        [Display(Name = "Packaged")]
        Packaged = 2
    }
}