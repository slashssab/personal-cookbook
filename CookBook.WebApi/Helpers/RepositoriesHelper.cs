using System.Collections.Generic;
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

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _repositoriesManager.RecipesRepository.GetAll();
        }

        public CookBookItem GetCookBookItem(int id)
        {
            return _repositoriesManager.CookBookItemsRepository.GetById(id);
        }

        public void InsertIngredient(Ingredient ingredient)
        {
            if (ingredient != null)
            {
                _repositoriesManager.IngredientsRepository.Insert(ingredient);
            }
        }
    }
}