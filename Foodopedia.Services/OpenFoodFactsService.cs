using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foodopedia.Core.Clients;
using Foodopedia.Core.Models;
using Foodopedia.Core.Services;

namespace Foodopedia.Services
{
    public class OpenFoodFactsService : IOpenFoodFactsService
    {
        private readonly IOpenFoodFactsClient _client;

        public OpenFoodFactsService(IOpenFoodFactsClient client)
        {
            _client = client;
        }

        public Task<IEnumerable<Product>> GetProductsByIngredient(string ingredient, int limit)
        {
            return _client.GetProductsByIngredient(ingredient, limit);
        }
    }
}
