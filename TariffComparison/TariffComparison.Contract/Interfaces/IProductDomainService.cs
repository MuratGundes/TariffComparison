using System.Collections.Generic;
using TariffComparison.Contract.Dtos;

namespace TariffComparison.Contract.Interfaces
{
    public interface IProductDomainService
    {
        List<ProductTariffDto> GetComparedProductsBasedOnAnnualCosts(decimal consumption);
    }
}