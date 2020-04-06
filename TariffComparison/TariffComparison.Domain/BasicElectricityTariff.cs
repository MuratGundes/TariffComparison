using TariffComparison.Common.Enums;
using TariffComparison.Contract.Interfaces;

namespace TariffComparison.Domain
{
    public class BasicElectricityTariff : ITariff
    {
        public TariffType Name => TariffType.Basic;
        private const decimal BaseCostPerMonth = 5;
        private const decimal ConsumptionCost = 0.22m;

        public decimal CalculateAnnualCost(decimal consumption)
        {
            return (BaseCostPerMonth * 12) + (consumption * ConsumptionCost);
        }
    }
}