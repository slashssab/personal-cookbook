namespace PersonalCookBook.Domain.RecipeAggregate
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Step> Steps { get; set; }

        private Recipe()
        {
            
        }

        public static Recipe Create(string name, string description, ICollection<Ingredient> ingredients, ICollection<Step> steps)
        {
            return new Recipe
            {
                Name = name,
                Description = description,
                Ingredients = ingredients,
                Steps = steps
            };
        }
    }
}
