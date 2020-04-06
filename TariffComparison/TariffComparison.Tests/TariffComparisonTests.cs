using System;
using System.Collections.Generic;
using System.Linq;
using TariffComparison.Contract.Dtos;
using TariffComparison.Contract.Interfaces;
using TariffComparison.Services;
using Moq;
using Xunit;

namespace TariffComparison.Tests
{
    public class TariffComparisonTests
    {
        //TODO: Check test setup for XUnit 

        [Fact]
        public void DomainShouldReturnDto()
        {
            // Arrange
            Mock<IProductDomainService> productDomainServiceMock = new Mock<IProductDomainService>(MockBehavior.Strict);
            IProductService productService = new ProductService(productDomainServiceMock.Object);
            var expectedResult = new List<ProductTariffDto>();

            // Act
            productDomainServiceMock.Setup(x => x.GetComparedProductsBasedOnAnnualCosts(It.IsAny<decimal>())).Returns(expectedResult);
            var actualResult = productService.GetComparedProductsBasedOnAnnualCosts(It.IsAny<decimal>());

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ShouldBeSuccesfullWhenConsumptionEqualsToZero()
        {
            // Arrange
            Mock<IProductDomainService> productDomainServiceMock = new Mock<IProductDomainService>(MockBehavior.Strict);
            IProductService productService = new ProductService(productDomainServiceMock.Object);
            var expectedResult = new List<ProductTariffDto>
            {
                new ProductTariffDto
                {
                    AnnualCost = 60,
                    TariffName = "Basic"
                },
                new ProductTariffDto
                {
                    AnnualCost = 800,
                    TariffName = "Packaged"
                }
            };

            // Act
            productDomainServiceMock.Setup(x => x.GetComparedProductsBasedOnAnnualCosts(default)).Returns(expectedResult);
            var actualResult = productService.GetComparedProductsBasedOnAnnualCosts(default);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(3500)]
        public void ShouldReturn830And800WhenConsumption3500(decimal consumption)
        {
            // Arrange
            Mock<IProductDomainService> productDomainServiceMock = new Mock<IProductDomainService>(MockBehavior.Strict);
            IProductService productService = new ProductService(productDomainServiceMock.Object);
            var expectedResult = new List<ProductTariffDto>
            {
                new ProductTariffDto
                {
                    AnnualCost = 830,
                    TariffName = "Basic"
                },
                new ProductTariffDto
                {
                    AnnualCost = 800,
                    TariffName = "Packaged"
                }
            };

            // Act
            productDomainServiceMock.Setup(x => x.GetComparedProductsBasedOnAnnualCosts(consumption)).Returns(expectedResult);
            var actualResult = productService.GetComparedProductsBasedOnAnnualCosts(consumption);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(3500)]
        public void ShouldReturnOrderedByAscending(decimal consumption)
        {
            // Arrange
            Mock<IProductDomainService> productDomainServiceMock = new Mock<IProductDomainService>(MockBehavior.Strict);
            IProductService productService = new ProductService(productDomainServiceMock.Object);
            var expectedResult = new List<ProductTariffDto>
            {
                new ProductTariffDto
                {
                    AnnualCost = 830,
                    TariffName = "Basic"
                },
                new ProductTariffDto
                {
                    AnnualCost = 800,
                    TariffName = "Packaged"
                }
            }.OrderBy(x => x.AnnualCost).ToList();

            // Act
            productDomainServiceMock.Setup(x => x.GetComparedProductsBasedOnAnnualCosts(consumption)).Returns(expectedResult);
            var actualResult = productService.GetComparedProductsBasedOnAnnualCosts(consumption);

            // Assert
            Assert.Equal(expectedResult.First().AnnualCost, actualResult.First().AnnualCost);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-20)]
        [InlineData(-300)]
        public void ShouldThrowExceptionWhenConsumptionLowerThanZero(decimal consumption)
        {
            // Arrange
            Mock<IProductDomainService> productDomainServiceMock = new Mock<IProductDomainService>(MockBehavior.Strict);
            IProductService productServiceSut = new ProductService(productDomainServiceMock.Object);

            // Act
            var exception = Assert.Throws<Exception>(() => productServiceSut.GetComparedProductsBasedOnAnnualCosts(consumption));

            // Assert
            Assert.Equal("Consumption cant be lower than 0", exception.Message);
        }
    }
}