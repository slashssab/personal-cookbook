using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonalCookBook.Database.Repositories;
using PersonalCookBook.Domain.RecipeAggregate;
using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Application.Recipes.ListRecipeHeaders
{
    public class ListRecipeHeadersQueryHandler(IRepository<Recipe> _recipeRepository) : IRequestHandler<ListRecipeHeadersQuery, RecipeHeaderResource[]>
    {
        public async Task<RecipeHeaderResource[]> Handle(ListRecipeHeadersQuery request, CancellationToken cancellationToken)
        {
            var recipes = await _recipeRepository.Query()
                .Include(r => r.Ingredients).ThenInclude(i => i.Product)
                .ToArrayAsync(cancellationToken);
            return recipes.Select(r => new RecipeHeaderResource(
                r.Id,
                r.Name,
                "default",
                r.Ingredients.Sum(i => i.Product.Kcal * i.Quantity / 100),
                new TimeSpan(1, 20, 0))).ToArray();
        }
    }
}
