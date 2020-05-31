using AutoMapper;
using Foodopedia.Api.Resources;
using Foodopedia.Core.Models;

namespace Foodopedia.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResource>();
        }
    }
}