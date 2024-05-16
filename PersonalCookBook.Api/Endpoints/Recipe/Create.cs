using FastEndpoints;
using MediatR;
using PersonalCookBook.Application.Recipes.CreateCommand;
using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Api.Endpoints.Recipe
{
    public class Create(ISender _sender) : Endpoint<CreateRecipeRequest, RecipeResource>
    {
        public override void Configure()
        {
            Post(CreateRecipeRequest.Route);
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateRecipeRequest request, CancellationToken cancellationToken)
        {
            var recipe = await _sender.Send(new CreateCommand(request.Name, request.Description, request.Steps, request.Ingredients), cancellationToken);

            if (recipe == null)
            {
                await SendNotFoundAsync(cancellationToken);
                return;
            }

            await SendCreatedAtAsync<Create>(new { recipe.Id }, recipe);
        }
    }
}
