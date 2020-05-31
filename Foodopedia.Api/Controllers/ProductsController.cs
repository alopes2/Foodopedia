using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Foodopedia.Api.Resources;
using Foodopedia.Core.Clients;
using Foodopedia.Core.Exceptions;
using Foodopedia.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Foodopedia.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IOpenFoodFactsService _service;
        public ProductsController(IOpenFoodFactsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResource>>> GetProducts(string ingredient, int limit)
        {
            var products = await _service.GetProductsByIngredient(ingredient, limit);

            var producResources = products.Select(p => new ProductResource
            {
                Name = p.Name,
                Ingredients = p.Ingredients
            });

            return Ok(producResources);
        }
    }
}
