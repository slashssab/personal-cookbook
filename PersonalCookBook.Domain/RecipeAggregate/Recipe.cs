namespace PersonalCookBook.Domain.RecipeAggregate
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ICollection<Ingredient> Ingredients { get; private set; }
        public ICollection<Step> Steps { get; private set; }

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

        public void UpdateName(string newName)
        {
            Name = newName;
        }

        public void UpdateDescription(string newDescription)
        {
            Description = newDescription;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            var existingIngredient = Ingredients.FirstOrDefault(i => i.ProductId == ingredient.ProductId);
            if (existingIngredient is not null)
            {
                existingIngredient.UpdateQuantity(existingIngredient.Quantity + ingredient.Quantity);
            }
            else
            {
                Ingredients.Add(ingredient);
            }
        }

        public void RemoveIngredient(Ingredient ingredient)
        {
            var existingIngredient = Ingredients.FirstOrDefault(i => i.ProductId == ingredient.ProductId);
            if (existingIngredient is not null)
            {
                Ingredients.Remove(ingredient);
            }
            else
            {
                throw new InvalidOperationException($"Cannot find ingredient Id: { ingredient.Id}");
            }
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            var existingIngredient = Ingredients.FirstOrDefault(i => i.ProductId == ingredient.ProductId);
            if (existingIngredient is not null)
            {
                existingIngredient.UpdateUnit(ingredient.Unit);
                existingIngredient.UpdateQuantity(ingredient.Quantity);
            }
            else
            {
                throw new InvalidOperationException($"Cannot find ingredient Id: {ingredient.Id}");
            }
        }

        public void UpdateIngredients(Ingredient[] ingredients)
        {
            var ingredientsToAdd = ingredients.Where(newIngredient => !Ingredients.Any(i => i.ProductId == newIngredient.ProductId)).ToArray();
            var ingredientsToRemove = Ingredients.Where(oldIngredient => !ingredients.Any(i => i.ProductId == oldIngredient.ProductId)).ToArray();
            var ingredientsToUpdate = ingredients.Where(oldIngredient => Ingredients.Any(i => i.ProductId == oldIngredient.ProductId)).ToArray();

            foreach (var ingredientToAdd in ingredientsToAdd)
            {
                AddIngredient(ingredientToAdd);
            }
            foreach (var ingredientToRemove in ingredientsToRemove)
            {
                RemoveIngredient(ingredientToRemove);
            }
            foreach (var ingredientToUpdate in ingredientsToUpdate)
            {
                UpdateIngredient(ingredientToUpdate);
            }
        }
    }
}
