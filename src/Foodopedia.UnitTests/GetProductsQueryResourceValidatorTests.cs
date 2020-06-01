using System.Threading.Tasks;
using Foodopedia.Api.Resources;
using Foodopedia.Api.Validators;
using Xunit;

namespace Foodopedia.UnitTests
{
    public class GetProductsQueryResourceValidatorTests
    {
        private readonly GetProductsQueryResourceValidator _validator;

        public GetProductsQueryResourceValidatorTests()
        {
            _validator = new GetProductsQueryResourceValidator();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task ValidateAsync_StringNullOrEmpty_ReturnIsValidFalseAsync(string ingredient)
        {
            var validLimit = 20;
            var query = new GetProductsQueryResource
            {
                Ingredient = ingredient,
                Limit = validLimit
            };

            var result = await _validator.ValidateAsync(query);

            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(21)]
        public async Task ValidateAsync_LimitLessThanTwoOrMoreThanTwenty_ReturnIsValidFalseAsync(int limit)
        {
            var validIngredient = "wheat";
            var query = new GetProductsQueryResource
            {
                Ingredient = validIngredient,
                Limit = limit
            };

            var result = await _validator.ValidateAsync(query);

            Assert.False(result.IsValid);
        }
    }
}