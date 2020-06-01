namespace Foodopedia.OpenFoodFacts.Models
{
    public class Product
    {
        public string product_name { get; set; }
        
        public Ingredient[] ingredients { get; set; }
    }
}