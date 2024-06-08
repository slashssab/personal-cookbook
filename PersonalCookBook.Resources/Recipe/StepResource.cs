using PersonalCookBook.Domain.RecipeAggregate.Enums;

namespace PersonalCookBook.Resources.Recipe
{
    public record StepResource(int Id, int Order, string Content, StepType Type);
}
