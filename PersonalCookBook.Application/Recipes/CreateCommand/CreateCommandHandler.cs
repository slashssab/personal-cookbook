using MediatR;
using PersonalCookBook.Domain.RecipeAggregate;
using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Application.Recipes.CreateCommand
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, RecipeResource>
    {
        public async Task<RecipeResource> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(500);
            var newRecipe = Recipe.Create(
                request.Name,
                request.Description,
                request.Ingredients.Select(i => new Ingredient
                {
                    ProductId = i.Product.Id,
                    Quantity = i.Quantity,
                    Unit = Domain.RecipeAggregate.Enums.Unit.Gram
                }).ToArray(),
                request.Steps.Select(s => new Step
                {
                    Order = s.Order,
                    Content = s.Content
                }).ToArray());

            return new RecipeResource(newRecipe.Id, request.Name, request.Ingredients, request.Steps);
        }
    }
}
