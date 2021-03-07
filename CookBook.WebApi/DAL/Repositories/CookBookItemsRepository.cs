using System.Collections.Generic;
using System.Linq;
using Cookbook.Common.Models;
using Cookbook.DAL.EF;

namespace Cookbook.WebApi.DAL.Repositories
{
    public class CookBookItemsRepository : ICookBookItemsRepository
    {
        private readonly CookbookContext _dbContext;
        public CookBookItemsRepository(CookbookContext context)
        {
            _dbContext = context;
        }

        public void Delete(int id)
        {
            var cookBookItemToRemove = this.GetById(id);
            if (cookBookItemToRemove != null)
            {
                _dbContext.CookBookItems.Remove(cookBookItemToRemove);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<CookBookItem> GetAll()
        {
            return _dbContext.CookBookItems;          
        }

        public CookBookItem GetById(int id)
        {
            return _dbContext.CookBookItems.SingleOrDefault(d => d.Id == id);
        }

        public void Insert(CookBookItem item)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Ingredient ingredient)
        {
            _dbContext.Ingredients.Add(ingredient);
            _dbContext.SaveChanges();
        }
    }
}