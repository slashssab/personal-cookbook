using PersonalCookBook.Domain.RecipeAggregate.Enums;
using PersonalCookBook.Resources.Product;

namespace PersonalCookBook.Resources.Recipe
{
    public record IngredientResource(ProductResource Product, double Quantity, Unit Unit);
}
