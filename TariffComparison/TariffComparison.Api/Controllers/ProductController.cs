using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TariffComparison.Contract.Dtos;
using TariffComparison.Contract.Interfaces;

namespace TariffComparison.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("tariffs/{consumption}")]
        public ActionResult<List<ProductTariffDto>> GetComparedProductsBasedOnAnnualCosts(decimal consumption)
        {
            return _productService.GetComparedProductsBasedOnAnnualCosts(consumption);
        }
    }
}