using MediatR;
using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Application.Recipes.CreateCommand
{
    public record CreateCommand(string Name, string Description, StepResource[] Steps, IngredientResource[] Ingredients): IRequest<RecipeResource>;
}
