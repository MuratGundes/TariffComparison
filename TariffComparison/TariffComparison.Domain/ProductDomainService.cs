using System;
using System.Collections.Generic;
using TariffComparison.Contract.Interfaces;

namespace TariffComparison.Domain
{
    public class ProductDomainService : IProductDomainService
    {
        public List<ITariff> GetComparedProductsBasedOnAnnualCosts(decimal consumption)
        {
            throw new NotImplementedException();
        }
    }
}