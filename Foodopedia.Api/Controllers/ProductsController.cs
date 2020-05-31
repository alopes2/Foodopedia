using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public ProductsController(IOpenFoodFactsService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResource>>> GetProducts([FromQuery] GetProductsQueryResource queryParams)
        {
            var products = await _service.GetProductsByIngredient(queryParams.Ingredient, queryParams.Limit);

            var producResources = _mapper.Map<IEnumerable<ProductResource>>(products);

            return Ok(producResources);
        }
    }
}