using System;
using System.Collections.Generic;
using System.Linq;
using Cookbook.Common.Models;
using Cookbook.DAL.EF;

namespace Cookbook.WebApi.DAL.Repositories
{
    public class DescriptionRepository : IDescriptionsRepository
    {
        private readonly CookbookContext _dbContext;
        public DescriptionRepository(CookbookContext context)
        {
            _dbContext = context;
        }

        public void Delete(int id)
        {
            var descriptionToRemove = this.GetById(id);
            if(descriptionToRemove != null)
            {
                _dbContext.Descriptions.Remove(descriptionToRemove);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Description> GetAll()
        {
            
            return _dbContext.Descriptions;
        }

        public Description GetById(int id)
        {
            return _dbContext.Descriptions.SingleOrDefault(r => r.Id == id);          
        }

        public IEnumerable<Description> GetByQuery(Func<Description, bool> query)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Description item)
        {
            _dbContext.Descriptions.Add(item);
            _dbContext.SaveChanges();
        }
    }
}