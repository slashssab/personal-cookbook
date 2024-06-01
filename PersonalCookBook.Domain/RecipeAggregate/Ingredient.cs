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

        public void Update(int productId, double quantity, Unit unit) 
        { 
            ProductId = productId;
            Quantity = quantity;
            Unit = unit;
        }

        public void UpdateQuantity(double newQuantity)
        {
            Quantity = newQuantity;
        }

        public void UpdateUnit(Unit unit)
        {
            Unit = unit;
        }
    }
}
