using System.Collections.Generic;
using TariffComparison.Contract.Dtos;

namespace TariffComparison.Contract.Interfaces
{
    public interface IProductService
    {
        List<ProductTariffDto> GetComparedProductsBasedOnAnnualCosts(decimal consumption);
    }
}