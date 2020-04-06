using System.Collections.Generic;
using System.Linq;
using TariffComparison.Contract.Dtos;
using TariffComparison.Contract.Interfaces;

namespace TariffComparison.Domain
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly IProductRepository _productRepository;

        public ProductDomainService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductTariffDto> GetComparedProductsBasedOnAnnualCosts(decimal consumption)
        {
            var products = _productRepository.GetProducts();

            return products.Select(tariff => new ProductTariffDto
            {
                AnnualCost = tariff.CalculateAnnualCost(consumption),
                TariffName = tariff.Name.ToString()
            }).OrderBy(x => x.AnnualCost).ToList();
        }
    }
}