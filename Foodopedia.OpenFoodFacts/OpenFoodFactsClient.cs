using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Foodopedia.Core.Clients;
using Foodopedia.Core.Exceptions;
using Foodopedia.Core.Extensions;
using Foodopedia.OpenFoodFacts.Models;
using CoreModels = Foodopedia.Core.Models;

namespace Foodopedia.OpenFoodFacts
{
    public class OpenFoodFactsClient : IOpenFoodFactsClient
    {
        private readonly HttpClient _client;
        private readonly IMapper _mapper;

        public OpenFoodFactsClient(HttpClient client, IMapper mapper)
        {
            _mapper = mapper;
            _client = client;
        }

        public async Task<IEnumerable<CoreModels.Product>> GetProductsByIngredient(string ingredient, int limit)
        {
            var url = $"search.pl?action=process&page_size={limit}&tagtype_0=ingredients&tag_contains_0=contains&tag_0={ingredient}&json=true";
            var response = await _client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var result = await response.ParseAsAsync<SearchResponse>();

            var products = _mapper.Map<IEnumerable<CoreModels.Product>>(result.products);
            
            return products;
        }
    }
}