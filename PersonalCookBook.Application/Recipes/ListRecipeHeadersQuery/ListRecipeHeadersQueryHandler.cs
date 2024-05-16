using MediatR;
using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Application.Recipes.ListRecipeHeaders
{
    public class ListRecipeHeadersQueryHandler : IRequestHandler<ListRecipeHeadersQuery, RecipeHeaderResource[]>
    {
        public async Task<RecipeHeaderResource[]> Handle(ListRecipeHeadersQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(500);
            return
                [
                    new RecipeHeaderResource(1, "Recipe 1", "Test Author 1", 1200, new TimeSpan(1,20,0)),
                    new RecipeHeaderResource(2, "Recipe 2", "Test Author 2", 1600, new TimeSpan(0,30,0)),
                    new RecipeHeaderResource(3, "Recipe 3", "Test Author 2", 2400, new TimeSpan(0,45,0)),
                    new RecipeHeaderResource(4, "Recipe 4", "Test Author 3", 800, new TimeSpan(0,20,0))
                ];
        }
    }
}
