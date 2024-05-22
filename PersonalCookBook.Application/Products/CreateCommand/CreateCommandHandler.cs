using MediatR;
using PersonalCookBook.Database.Repositories;
using PersonalCookBook.Domain.ProductAggregate;
using PersonalCookBook.Resources.Product;

namespace PersonalCookBook.Application.Products.CreateCommand
{
    public class CreateCommandHandler(IRepository<Product> _productRepository) : IRequestHandler<CreateCommand, ProductResource>
    {
        public async Task<ProductResource> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var newProduct = new Product
            {
                Name = request.Name,
                Kcal = request.Kcal,
                Protein = request.Protein,
                Carbs = request.Carbs,
            };

            await _productRepository.AddAsync(newProduct);
            await _productRepository.SaveChangesAsync();

            return new ProductResource(newProduct.Id, newProduct.Name, newProduct.Kcal, newProduct.Protein, newProduct.Carbs);
        }
    }
}
