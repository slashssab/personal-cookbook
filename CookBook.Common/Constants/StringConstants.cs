
namespace Cookbook.Common.Constants
{
    public static class StringConstants
    {
        public const string BaseUrl = @"https://localhost:5001/"; 
        public const string GetAllIngredientsApiAction = "_api/cookbookitems/GetAllIngredients";
        public const string GetAllRecipesApiAction = "_api/cookbookitems/GetAllRecipes";
        public const string GetRecipeByIdApiAction = "_api/cookbookitems/GetRecipeById/id?id={0}";
        public const string InsertIngredientApiAction = "_api/cookbookitems/InsertIngredient";
        public const string InsertRecipeApiAction = "_api/cookbookitems/InsertRecipe";
        public const string DeleteRecipeApiAction = "_api/cookbookitems/DeleteRecipe/id?id={0}";
        public const string DeleteIngredientApiAction = "_api/cookbookitems/DeleteIngredient/id?id={0}";
    }
}