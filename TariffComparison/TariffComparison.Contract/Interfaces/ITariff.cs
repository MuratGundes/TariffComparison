using TariffComparison.Common.Enums;

namespace TariffComparison.Contract.Interfaces
{
    public interface ITariff
    {
        TariffType Name { get; }
        decimal CalculateAnnualCost(decimal consumption);
    }
}