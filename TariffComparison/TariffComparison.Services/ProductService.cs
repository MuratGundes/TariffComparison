using System;
using System.Collections.Generic;
using TariffComparison.Contract.Dtos;
using TariffComparison.Contract.Interfaces;

namespace TariffComparison.Services
{
    //TODO: Logger Implementation
    public class ProductService : IProductService
    {
        private readonly IProductDomainService _productDomainService;

        public ProductService(IProductDomainService productDomainService)
        {
            _productDomainService = productDomainService;
        }

        public List<ProductTariffDto> GetComparedProductsBasedOnAnnualCosts(decimal consumption)
        {
            if (consumption < 0)
            {
                throw new Exception("Consumption cant be lower than 0");
            }

            var products = _productDomainService.GetComparedProductsBasedOnAnnualCosts(consumption);

            return products;
        }
    }
}