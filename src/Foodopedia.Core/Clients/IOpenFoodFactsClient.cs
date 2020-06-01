using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foodopedia.Core.Models;

namespace Foodopedia.Core.Clients
{
    public interface IOpenFoodFactsClient
    {
        Task<IEnumerable<Product>> GetProductsByIngredient(string ingredient, int limit);
    }
}