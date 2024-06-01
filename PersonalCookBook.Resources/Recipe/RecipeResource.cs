namespace PersonalCookBook.Resources.Recipe
{
    public record RecipeResource(int Id, string Name, string Description,IngredientResource[] Ingredients, StepResource[] Steps)
    {
        public double TotalCalories => Ingredients.Sum(i => i.TotalCalories);
        public double TotalProteins => Ingredients.Sum(i => i.TotalProteins);
    };
}
