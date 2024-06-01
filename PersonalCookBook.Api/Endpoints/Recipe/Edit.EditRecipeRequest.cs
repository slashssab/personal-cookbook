using FastEndpoints;
using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Api.Endpoints.Recipe
{
    public class EditRecipeRequest
    {
        public const string Route = "api/Recipe/{id:int}/edit";

        [QueryParam]
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public IngredientResource[] Ingredients { get; init; }
        public StepResource[] Steps { get; init; }
    }
}
