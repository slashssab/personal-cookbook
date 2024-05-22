using MediatR;
using PersonalCookBook.Resources.Product;

namespace PersonalCookBook.Application.Products.CreateCommand
{
    public record CreateCommand(string Name, double Kcal, double Protein, double Carbs) : IRequest<ProductResource>;
}
