using MediatR;
using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Application.Recipes.ListRecipeHeaders
{
    public record ListRecipeHeadersQuery : IRequest<RecipeHeaderResource[]>;
}
