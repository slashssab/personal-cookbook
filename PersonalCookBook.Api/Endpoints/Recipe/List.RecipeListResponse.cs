using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Api.Endpoints.Recipe
{
    public class RecipeListResponse
    {
        public RecipeHeaderResource[] Recipes { get; init; } = [];
    }
}
