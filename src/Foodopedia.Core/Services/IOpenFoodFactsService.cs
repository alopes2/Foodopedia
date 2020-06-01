using System.Collections.Generic;
using System.Threading.Tasks;
using Foodopedia.Core.Models;

namespace Foodopedia.Core.Services
{
    public interface IOpenFoodFactsService
    {
        Task<IEnumerable<Product>> GetProductsByIngredient(string ingredient, int limit);
    }
}