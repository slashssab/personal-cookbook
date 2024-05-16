using FastEndpoints;
using MediatR;
using PersonalCookBook.Application.Recipes.ListRecipeHeaders;
using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Api.Endpoints.Recipe
{
    public class List(ISender _sender) : EndpointWithoutRequest<RecipeListResponse>
    {
        public override void Configure()
        {
            Get("api/Recipes");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            RecipeHeaderResource[] result = await _sender.Send(new ListRecipeHeadersQuery(), cancellationToken);

            Response = new RecipeListResponse
            {
                Recipes = result
            };
        }
    }
}
