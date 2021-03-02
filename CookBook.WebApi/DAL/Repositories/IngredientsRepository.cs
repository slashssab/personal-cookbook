using System.Collections.Generic;
using System.Linq;
using Cookbook.Common.Models;
using Cookbook.DAL.EF;

namespace Cookbook.WebApi.DAL.Repositories
{
    public class IngredientsRepository : IIngredientsRepository
    {
        private readonly CookbookContext _dbContext;
        public IngredientsRepository(CookbookContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _dbContext.Ingredients;
        }

        public Ingredient GetById(int id)
        {
            return _dbContext.Ingredients.SingleOrDefault(r => r.Id == id);          
        }

        public void Insert(Ingredient item)
        {
            _dbContext.Ingredients.Add(item);
            _dbContext.SaveChanges();
        }
    }
}