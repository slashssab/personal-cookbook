using PersonalCookBook.Domain.RecipeAggregate.Enums;

namespace PersonalCookBook.Domain.RecipeAggregate
{
    public class Step
    {
        public int RecipeId { get; set; }
        public int Order {  get; set; }
        public string Content { get; set; }
        public StepType Type { get; set; }
    }
}
