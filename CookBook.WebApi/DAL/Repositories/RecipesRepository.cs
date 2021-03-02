using System.Collections.Generic;
using System.Linq;
using Cookbook.Common.Models;
using Cookbook.DAL.EF;

namespace Cookbook.WebApi.DAL.Repositories
{
    public class RecipesRepository : IRecipesRepository
    {
        private readonly CookbookContext _dbContext;
        public RecipesRepository(CookbookContext context)
        {
            _dbContext = context;
        }
        public IEnumerable<Recipe> GetAll()
        {
            return _dbContext.Recipes;          
        }

        public Recipe GetById(int id)
        {
            return _dbContext.Recipes.SingleOrDefault(r => r.Id == id);          
        }

        public void Insert(Recipe item)
        {
            _dbContext.Recipes.Add(item);
            _dbContext.SaveChanges();
        }
    }
}