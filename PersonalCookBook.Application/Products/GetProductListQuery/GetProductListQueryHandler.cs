using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonalCookBook.Database.Repositories;
using PersonalCookBook.Domain.ProductAggregate;
using PersonalCookBook.Resources.Product;

namespace PersonalCookBook.Application.Products.GetProductListQuery
{
    public class GetProductListQueryHandler(IRepository<Product> _productRepositor) : IRequestHandler<GetProductListQuery, ProductResource[]>
    {
        public async Task<ProductResource[]> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepositor.Query().ToArrayAsync(cancellationToken);
            return products.Select(p => new ProductResource(
                p.Id,
                p.Name,
                p.Kcal,
                p.Protein,
                p.Carbs
                )).ToArray();
        }
    }
}
