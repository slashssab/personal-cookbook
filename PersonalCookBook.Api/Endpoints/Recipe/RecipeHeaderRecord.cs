namespace PersonalCookBook.Api.Endpoints.Recipe
{
    public record RecipeHeaderRecord(int Id, string RecipeName, string Author, double TotalCalories, TimeSpan PreparationTime);
}
