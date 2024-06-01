using FastEndpoints;
using MediatR;
using PersonalCookBook.Application.Recipes.EditRecipeCommand;
using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Api.Endpoints.Recipe
{
    public class Edit(ISender _sender) : Endpoint<EditRecipeRequest, RecipeResource>
    {
        public override void Configure()
        {
            Post(EditRecipeRequest.Route);
            AllowAnonymous();
        }

        public override async Task HandleAsync(EditRecipeRequest request, CancellationToken cancellationToken)
        {
            var recipe = await _sender.Send(new EditRecipeCommand(request.Id, request.Name, request.Description, request.Steps, request.Ingredients), cancellationToken);

            if (recipe == null)
            {
                await SendNotFoundAsync(cancellationToken);
                return;
            }

            await SendAsync(recipe);
        }
    }
}
