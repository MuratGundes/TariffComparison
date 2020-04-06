using System.Collections.Generic;
using TariffComparison.Contract.Interfaces;
using TariffComparison.Domain;

namespace TariffComparison.Repository
{
    public class ProductRepository : IProductRepository
    {
        public List<ITariff> GetProducts()
        {
            return new List<ITariff>
            {
                new BasicElectricityTariff(),
                new PackagedTariff()
            };
        }
    }
}