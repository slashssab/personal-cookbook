using FastEndpoints;
using MediatR;
using PersonalCookBook.Application.Products.CreateCommand;
using PersonalCookBook.Resources.Product;

namespace PersonalCookBook.Api.Endpoints.Product
{
    public class Create(ISender _sender) : Endpoint<CreateProductRequest, ProductResource>
    {
        public override void Configure()
        {
            Post(CreateProductRequest.Route);
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var newProduct = await _sender.Send(new CreateCommand(request.Name, request.Kilocalories, request.Proteins, request.Carbohydrates), cancellationToken);

            if (newProduct == null)
            {
                await SendNotFoundAsync(cancellationToken);
                return;
            }

            await SendCreatedAtAsync<Create>(new { newProduct.Id }, newProduct);
        }
    }
}
