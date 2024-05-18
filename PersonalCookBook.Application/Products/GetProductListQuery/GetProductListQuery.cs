using MediatR;
using PersonalCookBook.Resources.Product;

namespace PersonalCookBook.Application.Products.GetProductListQuery
{
    public record GetProductListQuery() : IRequest<ProductResource[]>;
}
