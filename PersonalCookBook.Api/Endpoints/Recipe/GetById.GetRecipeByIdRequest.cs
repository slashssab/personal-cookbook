using FastEndpoints;

namespace PersonalCookBook.Api.Controllers.Recipe
{
    public class GetRecipeByIdRequest
    {
        public const string Route = "api/Recipe/{RecipeId:int}";
        public static string BuildRoute(int recipeId) => Route.Replace("{RecipeId:int}", recipeId.ToString());

        [QueryParam]
        public int RecipeId { get; set; }
    }
}
