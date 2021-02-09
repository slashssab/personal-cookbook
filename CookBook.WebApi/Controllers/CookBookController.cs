using Microsoft.AspNetCore.Mvc;
using Cookbook.Common.Models;
using System.Collections.Generic;
using Cookbook.DAL;
using Cookbook.DAL.EF;

namespace Cookbook.Controllers
{
    [ApiController]
    [Route("cookbookitems")]
    public class CookBookController: ControllerBase
    {
        private readonly InMemoryRepository _repository;
        private readonly CookbookContext _dbContext;
        public CookBookController(CookbookContext context){
            _repository = new InMemoryRepository();
            _dbContext = context;
        }

        [HttpGet]
        public IEnumerable<CookBookItem> GetCookBookItems()
        {
            return _repository.GetCookBookItems();
        }

        [HttpGet("int: id")]
        public CookBookItem GetCookBookItemsById(int id)
        {
            return _repository.GetCookBookItem(id);
        }

        [HttpPost]
        public IActionResult PostDescription()
        {
            var coo = new CookBookItem
            {
                IngredientId = 1,
                RecipeId = 2,
                Ingredient = new Ingredient
                {
                    Name = "Test_2",
                    Kcal100 = 28
                },
                Recipe = new Recipe
                {
                    DescriptionID = 2,
                    Name = "Test_2"
                }
                };
            _dbContext.CookBookItems.Add(coo);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}