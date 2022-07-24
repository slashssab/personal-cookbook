using CookBook.Database.Models;

namespace CookBook.Database
{
    public interface IDataProvider
    {
        IEnumerable<Ingredient> GetAllIngredients();
        Ingredient GetIngredientByName(string name);
        IEnumerable<Recipe> GetAllRecipes();
        Recipe GetRecipeById(int id);
        CookBookItem GetCookBookItem(int id);
        IEnumerable<CookBookItem> GetCookBookItemsByRecipeId(int id);
        Description GetDescriptionById(int id);
        void InsertIngredient(Ingredient ingredient);
        void InsertRecipe(Recipe recipe);
        void DeleteIngredient(int id);
        void DeleteRecipe(int id);
    }
}
