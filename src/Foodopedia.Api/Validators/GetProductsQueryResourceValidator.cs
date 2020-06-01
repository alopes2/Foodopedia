using FluentValidation;
using Foodopedia.Api.Resources;

namespace Foodopedia.Api.Validators
{
    public class GetProductsQueryResourceValidator : AbstractValidator<GetProductsQueryResource>
    {
        public GetProductsQueryResourceValidator()
        {
            RuleFor(q => q.Ingredient)
                .NotEmpty();

            RuleFor(q => q.Limit)
                .InclusiveBetween(2, 20); // If limit 1 is passed to OpenFoodFacts it return page size 20
        }
    }
}