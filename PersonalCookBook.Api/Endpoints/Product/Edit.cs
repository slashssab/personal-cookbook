using FastEndpoints;
using MediatR;
using PersonalCookBook.Application.Products.EditCommand;
using PersonalCookBook.Resources.Product;

namespace PersonalCookBook.Api.Endpoints.Product
{
    public class Edit(ISender _sender) : Endpoint<EditProductRequest, ProductResource>
    {
        public override void Configure()
        {
            Post(EditProductRequest.Route);
            AllowAnonymous();
        }

        public override async Task HandleAsync(EditProductRequest request, CancellationToken cancellationToken)
        {
            var newProduct = await _sender.Send(new EditProductCommand(request.Id, request.Name, request.Kilocalories, request.Proteins, request.Carbohydrates), cancellationToken);

            if (newProduct == null)
            {
                await SendNotFoundAsync(cancellationToken);
                return;
            }

            await SendOkAsync(newProduct, cancellationToken);
        }
    }
}
