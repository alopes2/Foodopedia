using System.Collections.Generic;

namespace Foodopedia.Core.Models
{
    public class Product
    {
        public string Name { get; set; }

        public ICollection<string> Ingredients { get; set; }
    }
}