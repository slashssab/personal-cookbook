using PersonalCookBook.Domain.RecipeAggregate.Enums;

namespace PersonalCookBook.Domain.RecipeAggregate
{
    public class Step
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int Order {  get; set; }
        public string Content { get; set; }
        public StepType Type { get; set; }

        public void UpdateContent(string newContent)
        {
            Content = newContent;
        }

        public void UpdateType(StepType type)
        {
            Type = type;
        }
    }
}
