using MediatR;
using PersonalCookBook.Resources.Product;

namespace PersonalCookBook.Application.Products.EditCommand
{
    public record EditProductCommand(int Id, string Name, double Kcal, double Protein, double Carbs) : IRequest<ProductResource>;
}
