using System.Collections.Generic;

namespace TariffComparison.Contract.Interfaces
{
    public interface IProductRepository
    {
        List<ITariff> GetProducts();
    }
}