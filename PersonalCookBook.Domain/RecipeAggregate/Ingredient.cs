using PersonalCookBook.Domain.ProductAggregate;
using PersonalCookBook.Domain.RecipeAggregate.Enums;

namespace PersonalCookBook.Domain.RecipeAggregate
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public Unit Unit { get; set; }
        public Product Product { get; set; }
    }
}
