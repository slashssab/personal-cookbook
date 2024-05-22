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

            //return
            //    [
            //    new ProductResource(1, "Chicken Breast", 165, 31, 0),
            //    new ProductResource(2, "Pesto", 414, 6.2, 0),
            //    new ProductResource(3, "Turkey", 165, 31, 0),
            //    new ProductResource(4, "Knor Napoli", 165, 31, 0),
            //    new ProductResource(5, "Water", 0, 0, 0),
            //    new ProductResource(6, "Pasta", 354, 12, 25)
            //    ];
        }
    }
}
