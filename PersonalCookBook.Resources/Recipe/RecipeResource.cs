namespace PersonalCookBook.Resources.Recipe
{
    public record RecipeResource(int Id, string Name, IngredientResource[] Ingredients, StepResource[] Steps);
}
