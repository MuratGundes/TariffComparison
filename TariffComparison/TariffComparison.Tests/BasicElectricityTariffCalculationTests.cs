using TariffComparison.Contract.Interfaces;
using TariffComparison.Domain;
using Xunit;

namespace TariffComparison.Tests
{
    public class BasicElectricityTariffCalculationTests
    {
        [Theory]
        [InlineData(830, 3500)]
        [InlineData(1050, 4500)]
        [InlineData(1380, 6000)]
        public void ConsumptionCostsShouldBeAsExpected(decimal annualCost, decimal consumption)
        {
            // Arrange
            ITariff tariff = new BasicElectricityTariff();

            // Act
            var consumptionCost = tariff.CalculateAnnualCost(consumption);

            // Assert
            Assert.Equal(annualCost, consumptionCost);
        }
    }
}