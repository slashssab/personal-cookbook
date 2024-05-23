using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonalCookBook.Database.Repositories;
using PersonalCookBook.Domain.ProductAggregate;
using PersonalCookBook.Resources.Product;

namespace PersonalCookBook.Application.Products.EditCommand
{
    public class EditProductCommandHandler(IRepository<Product> _productRepository) : IRequestHandler<EditProductCommand, ProductResource>
    {
        public async Task<ProductResource> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Query(true).FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            product.UpdateName(request.Name);
            product.UpdateProteins(request.Protein);
            product.UpdateCalories(request.Kcal);
            product.UpdateCarbohydrates(request.Carbs);

            await _productRepository.SaveChangesAsync();
            return new ProductResource(
                product.Id,
                product.Name,
                product.Kcal,
                product.Protein,
                product.Carbs
                );
        }
    }
}
