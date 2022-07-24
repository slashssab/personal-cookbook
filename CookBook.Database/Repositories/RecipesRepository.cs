using CookBook.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Database.Repositories
{
    public class RecipesRepository : IRecipesRepository
    {
        private readonly CookbookContext _dbContext;
        public RecipesRepository(CookbookContext context)
        {
            _dbContext = context;
        }

        public void Delete(int id)
        {
            var recipeToRemove = _dbContext.Recipes.Where(e => e.Id == id)
            .Include(e => e.CookBookItems)
            .Include(e => e.Description)
            .First();

            if(recipeToRemove != null)
            {
                _dbContext.Remove(recipeToRemove);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _dbContext.Recipes
            .Include(e => e.CookBookItems)
            .ThenInclude(ci => ci.Ingredient)
            .Include(e => e.Description);
        }

        public Recipe GetById(int id)
        {
            return _dbContext.Recipes
            .Include(e => e.CookBookItems)
            .ThenInclude(ci => ci.Ingredient)
            .Include(e => e.Description)
            .SingleOrDefault(r => r.Id == id);          
        }

        public IEnumerable<Recipe> GetByQuery(Func<Recipe, bool> query)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Recipe item)
        {
            _dbContext.Recipes.Add(item);
            _dbContext.SaveChanges();
        }
    }
}