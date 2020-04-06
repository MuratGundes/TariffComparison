using TariffComparison.Common.Enums;
using TariffComparison.Contract.Interfaces;

namespace TariffComparison.Domain
{
    public class PackagedTariff : ITariff
    {
        public TariffType Name => TariffType.Packaged;
        private const decimal BaseCostPerMonth = 800;
        private const decimal ConsumptionCost = 0.30m;
        private const decimal ConsumptionThreshold = 4000;

        public decimal CalculateAnnualCost(decimal consumption)
        {
            if (consumption < ConsumptionThreshold)
            {
                return BaseCostPerMonth;
            }

            return BaseCostPerMonth + (consumption - ConsumptionThreshold) * ConsumptionCost;
        }
    }
}