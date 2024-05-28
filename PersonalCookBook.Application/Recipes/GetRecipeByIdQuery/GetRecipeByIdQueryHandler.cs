using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonalCookBook.Database.Repositories;
using PersonalCookBook.Domain.RecipeAggregate;
using PersonalCookBook.Resources.Product;
using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Application.Recipes.GetRecipeByIdQuery
{
    public class GetRecipeByIdQueryHandler(IRepository<Recipe> _recipeRepository) : IRequestHandler<GetRecipeByIdQuery, RecipeResource>
    {
        public async Task<RecipeResource> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRepository.Query()
                .Include(r => r.Ingredients).ThenInclude(r => r.Product)
                .FirstOrDefaultAsync(r => r.Id == request.Id);
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

            return new RecipeResource(recipe.Id, recipe.Name, ingredients, []);
        }
    }
}
