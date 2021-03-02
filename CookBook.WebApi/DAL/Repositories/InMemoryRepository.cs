using System.Collections.Generic;
using System.Linq;
using Cookbook.Common.Models;

namespace Cookbook.WebApi.DAL.Repositories
{
    public class InMemoryRepository
    {
        private readonly List<CookBookItem> _cookbookItems = new()
        {
            new CookBookItem { IngredientId = 1, RecipeId = 3 },
            new CookBookItem { IngredientId = 2, RecipeId = 4 }
        };

        public List<CookBookItem> GetCookBookItems()
        {
            return _cookbookItems;
        }

        public CookBookItem GetCookBookItem(int id)
        {
            return _cookbookItems.Where(d => d.RecipeId == id).SingleOrDefault();
        }
    }
}