using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Common.Models;

namespace CookBook.WebPage.Utils
{
    public class CookBookData
    {
        private static IEnumerable<Ingredient> _ingredientsCollection;
        public async static Task<IEnumerable<Ingredient>> GetIngredientsCollection()
        {
            if(_ingredientsCollection == null)
            {
                _ingredientsCollection = await Helpers.CookBookReciver.GetAlIngredients();
            }
            return _ingredientsCollection;
        }

        public static Ingredient GetIngredientIdByName(string name)
        {
            return _ingredientsCollection.Single(i => i.Name == name);
        }
    }
}