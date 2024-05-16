using FastEndpoints;
using MediatR;
using PersonalCookBook.Api.Controllers.Recipe;
using PersonalCookBook.Application.Recipes.GetRecipeByIdQuery;
using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Api.Endpoints.Recipe
{
    public class GetById(ISender _sender) : Endpoint<GetRecipeByIdRequest, RecipeResource>
    {
        public override void Configure()
        {
            Get(GetRecipeByIdRequest.Route);
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetRecipeByIdRequest request, CancellationToken cancellationToken)
        {
            var recipe = await _sender.Send(new GetRecipeByIdQuery(request.RecipeId), cancellationToken);
            
            if (recipe == null)
            {
                await SendNotFoundAsync(cancellationToken);
                return;
            }

            Response = recipe;
        }
    }
}
