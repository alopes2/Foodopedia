using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Foodopedia.Api.Resources
{
    public class ProductResource
    {
        public ProductResource()
        {
            Ingredients = new Collection<string>();
        }

        public string Name { get; set; }

        public ICollection<string> Ingredients { get; set; }
    }
}