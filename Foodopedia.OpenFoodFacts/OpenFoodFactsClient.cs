using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Foodopedia.Core.Clients;
using Foodopedia.Core.Exceptions;
using Foodopedia.OpenFoodFacts.Models;
using CoreModels = Foodopedia.Core.Models;

namespace Foodopedia.OpenFoodFacts
{
    public class OpenFoodFactsClient : IOpenFoodFactsClient
    {
        private readonly HttpClient _client;

        public OpenFoodFactsClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<CoreModels.Product>> GetProductsByIngredient(string ingredient, int limit)
        {
            var url = $"search.pl?action=process&page_size={limit}&tagtype_0=ingredients&tag_contains_0=contains&tag_0={ingredient}&json=true";
            var response = await _client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<SearchResponse>(responseString);

            return result.products.Select(p => new CoreModels.Product
            {
                Name = p.product_name,
                Ingredients = p.ingredients.Select(i => i.text).ToList()
            });
        }
    }
}