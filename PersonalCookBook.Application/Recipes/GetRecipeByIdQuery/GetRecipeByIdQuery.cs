using MediatR;
using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Application.Recipes.GetRecipeByIdQuery
{
    public record GetRecipeByIdQuery(int Id) : IRequest<RecipeResource>;
}
