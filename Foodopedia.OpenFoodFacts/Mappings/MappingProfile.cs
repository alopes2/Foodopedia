using System.Linq;
using AutoMapper;
using Foodopedia.OpenFoodFacts.Models;

namespace Foodopedia.OpenFoodFacts.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, Core.Models.Product>()
                .ForMember(cp => cp.Name, opt => opt.MapFrom(p => p.product_name))
                .ForMember(cp => cp.Ingredients, opt => opt.MapFrom(p => p.ingredients.Select(i => i.text)));
        }
    }
}