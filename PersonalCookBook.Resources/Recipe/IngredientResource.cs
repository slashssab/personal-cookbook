using PersonalCookBook.Resources.Product;

namespace PersonalCookBook.Resources.Recipe
{
    public record IngredientResource(ProductResource Product, int Quantity);
}
