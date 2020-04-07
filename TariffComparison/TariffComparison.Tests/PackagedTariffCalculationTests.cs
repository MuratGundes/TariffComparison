using TariffComparison.Contract.Interfaces;
using TariffComparison.Domain;
using Xunit;

namespace TariffComparison.Tests
{
    public class PackagedTariffCalculationTests
    {
        [Theory]
        [InlineData(800, 3500)]
        [InlineData(950, 4500)]
        [InlineData(1400, 6000)]
        public void ConsumptionCostsShouldBeAsExpected(decimal annualCost, decimal consumption)
        {
            // Arrange
            ITariff tariff = new PackagedTariff();

            // Act
            var consumptionCost = tariff.CalculateAnnualCost(consumption);

            // Assert
            Assert.Equal(annualCost, consumptionCost);
        }
    }
}