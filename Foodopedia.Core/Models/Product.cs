using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Foodopedia.Core.Models
{
    public class Product
    {
        public Product()
        {
            Ingredients = new Collection<string>();
        }

        public string Name { get; set; }

        public ICollection<string> Ingredients { get; set; }
    }
}