using PersonalCookBook.Domain.RecipeAggregate.Enums;
using PersonalCookBook.Resources.Product;

namespace PersonalCookBook.Resources.Recipe
{
    public record IngredientResource(ProductResource Product, double Quantity, Unit Unit)
    {
        public double TotalCalories => Product.Kcal * Quantity / 100;
        public double TotalProteins => Product.Protein * Quantity / 100;
    };

}
