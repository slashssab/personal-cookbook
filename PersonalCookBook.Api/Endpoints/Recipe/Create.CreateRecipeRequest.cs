using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Api.Endpoints.Recipe
{
    public class CreateRecipeRequest
    {
        public const string Route = "/Recipe";

        public string Name { get; init; }
        public string Description { get; init; }
        public IngredientResource[] Ingredients { get; init; }
        public StepResource[] Steps { get; init; }
    }
}
