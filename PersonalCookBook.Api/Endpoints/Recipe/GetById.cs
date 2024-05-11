using FastEndpoints;
using MediatR;
using PersonalCookBook.Api.Controllers.Recipe;

namespace PersonalCookBook.Api.Endpoints.Recipe
{
    public class GetById(ISender _sender) : Endpoint<GetRecipeByIdRequest, RecipeHeaderRecord>
    {
        public override void Configure()
        {
            Get(GetRecipeByIdRequest.Route);
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetRecipeByIdRequest request, CancellationToken cancellationToken)
        {
            //var query = new GetContributorQuery(request.ContributorId);

            //var result = await _mediator.Send(query, cancellationToken);

            //if (result.Status == ResultStatus.NotFound)
            //{
            //    await SendNotFoundAsync(cancellationToken);
            //    return;
            //}

            //if (result.IsSuccess)
            //{
            //    Response = new ContributorRecord(result.Value.Id, result.Value.Name, result.Value.PhoneNumber);
            //}

            Response = new RecipeHeaderRecord(request.RecipeId, "Test Recipe", "Test Author", 1000, new TimeSpan(1,3,0));
        }
    }
}
