using FastEndpoints;
using MediatR;
using PersonalCookBook.Api.Endpoints.Recipe;
using PersonalCookBook.Application.Products.GetProductListQuery;
using PersonalCookBook.Application.Recipes.ListRecipeHeaders;
using PersonalCookBook.Resources.Product;
using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Api.Endpoints.Product
{
    public class List(ISender _sender) : EndpointWithoutRequest<ProductListResponse>
    {
        public override void Configure()
        {
            Get("api/Products");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            ProductResource[] result = await _sender.Send(new GetProductListQuery(), cancellationToken);

            Response = new ProductListResponse
            {
                Products = result
            };
        }
    }
}
