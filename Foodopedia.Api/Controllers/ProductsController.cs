using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Foodopedia.Api.Resources;
using Foodopedia.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Foodopedia.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController()
        {  }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResource>>> GetProducts(string ingredient, int limit)
        {
            var producResources = await Task.FromResult(new List<ProductResource>
            {
                new ProductResource
                {
                    Name = "Spaghetti",
                    Ingredients = new List<string>
                    {
                        "Flour",
                        "Water",
                        "Meat",
                        "Tomato"
                    }
                },
                new ProductResource
                {
                    Name = "Vanilla Cake",
                    Ingredients = new List<string>
                    {
                        "Flour",
                        "Water",
                        "Vanilla",
                        "Sugar"
                    }
                }
            });
            
            return Ok(producResources);
        }
    }
}
