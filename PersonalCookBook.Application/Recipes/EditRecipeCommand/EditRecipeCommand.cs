using MediatR;
using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Application.Recipes.EditRecipeCommand
{
    public record EditRecipeCommand(int Id, string Name, string Description, StepResource[] Steps, IngredientResource[] Ingredients) : IRequest<RecipeResource>;
}
