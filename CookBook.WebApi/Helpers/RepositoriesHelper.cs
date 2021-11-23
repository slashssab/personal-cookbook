using System.Collections.Generic;
using System.Linq;
using Cookbook.Common.Models;
using Cookbook.DAL.EF;
using Cookbook.WebApi.DAL.Repositories;

namespace Cookbook.WebApi.Helpers
{
    public class RepositoriesHelper
    {
        private RepositoriesManager _repositoriesManager;
        public RepositoriesHelper(CookbookContext _context)
        {
            _repositoriesManager = new RepositoriesManager(_context);
        }

        public IEnumerable<Ingredient> GetAllIngredients()
        {
            return _repositoriesManager.IngredientsRepository.GetAll();
        }

        public Ingredient GetIngredientByName(string name)
        {
            return _repositoriesManager.IngredientsRepository.GetByQuery(i => i.Name == name).Single();
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _repositoriesManager.RecipesRepository.GetAll();
        }

        public Recipe GetRecipeById(int id)
        {
            return _repositoriesManager.RecipesRepository.GetById(id);
        }

        public CookBookItem GetCookBookItem(int id)
        {
            return _repositoriesManager.CookBookItemsRepository.GetById(id);
        }
        
        public IEnumerable<CookBookItem> GetCookBookItemsByRecipeId(int id)
        {
            return _repositoriesManager.CookBookItemsRepository.GetByQuery(ci => ci.RecipeId == id);
        }

        public Description GetDescriptionById(int id)
        {
            return _repositoriesManager.DescriptionsRepository.GetById(id);
        }

        public void InsertIngredient(Ingredient ingredient)
        {
            if (ingredient != null)
            {
                _repositoriesManager.IngredientsRepository.Insert(ingredient);
            }
        }

        public void InsertRecipe(Recipe recipe)
        {
            if (recipe != null)
            {
                _repositoriesManager.RecipesRepository.Insert(recipe);
            }
        }

        public void DeleteIngredient(int id)
        {
            _repositoriesManager.IngredientsRepository.Delete(id);
        }

        public void DeleteRecipe(int id)
        {
            _repositoriesManager.RecipesRepository.Delete(id);
        }
    }
}