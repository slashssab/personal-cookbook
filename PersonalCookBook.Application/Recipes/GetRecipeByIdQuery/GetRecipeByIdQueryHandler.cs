using MediatR;
using PersonalCookBook.Database.Repositories;
using PersonalCookBook.Resources.Product;
using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Application.Recipes.GetRecipeByIdQuery
{
    public class GetRecipeByIdQueryHandler(IRecipeRepository _recipeRepository) : IRequestHandler<GetRecipeByIdQuery, RecipeResource>
    {
        public async Task<RecipeResource> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRepository.GetRecipeAggregateAsync(request.Id, cancellationToken);
            
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }

            var ingredients = recipe.Ingredients.Select(i =>
                 new IngredientResource(
                     new ProductResource(
                                    i.Product.Id,
                                    i.Product.Name,
                                    i.Product.Kcal,
                                    i.Product.Protein,
                                    i.Product.Carbs)
                                ,
                    i.Quantity,
                    Domain.RecipeAggregate.Enums.Unit.Gram
                )
            ).ToArray();

            var steps = recipe.Steps.Select(s =>
                 new StepResource(
                    s.Id,
                    s.Order,
                    s.Content,
                    s.Type
                )
            ).ToArray();

            return new RecipeResource(recipe.Id, recipe.Name, recipe.Description,ingredients, steps);
        }
    }
}
