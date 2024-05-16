namespace PersonalCookBook.Resources.Recipe
{
    public record RecipeHeaderResource(int Id, string RecipeName, string Author, double TotalCalories, TimeSpan PreparationTime);
}
