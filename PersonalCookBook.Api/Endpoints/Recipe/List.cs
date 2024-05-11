using FastEndpoints;
using MediatR;

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
            //Result<IEnumerable<ContributorDTO>> result = await _mediator.Send(new ListContributorsQuery(null, null), cancellationToken);

            //if (result.IsSuccess)
            //{

            //}
            Response = new RecipeListResponse
            {
                Recipes =
                    [
                        new RecipeHeaderRecord(1, "Recipe 1", "Test Author 1", 1200, new TimeSpan(1,20,0)),
                        new RecipeHeaderRecord(2, "Recipe 2", "Test Author 2", 1600, new TimeSpan(0,30,0)),
                        new RecipeHeaderRecord(3, "Recipe 3", "Test Author 2", 2400, new TimeSpan(0,45,0)),
                        new RecipeHeaderRecord(4, "Recipe 4", "Test Author 3", 800, new TimeSpan(0,20,0))
                    ]
            };
        }
    }
}
