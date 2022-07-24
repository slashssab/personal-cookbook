using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CookBook.Database;
using CookBook.Database.Models;

namespace Cookbook.Controllers
{
    [ApiController]
    [Route("_api/cookbookitems/[Action]")]
    public class CookBookController : ControllerBase
    {
        private readonly IDataProvider _dataProvider;
        public CookBookController(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        [HttpGet]
        [ActionName(nameof(GetAllIngredients))]
        public IEnumerable<Ingredient> GetAllIngredients()
        {
            return _dataProvider.GetAllIngredients();
        }

        [HttpGet]
        [ActionName(nameof(GetAllRecipes))]
        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _dataProvider.GetAllRecipes();
        }

        [HttpGet("id")]
        [ActionName(nameof(GetCookBookItemById))]
        public CookBookItem GetCookBookItemById(int id)
        {
            return _dataProvider.GetCookBookItem(id);
        }

        [HttpGet("id")]
        [ActionName(nameof(GetRecipeById))]
        public Recipe GetRecipeById(int id)
        {
            return _dataProvider.GetRecipeById(id);
        }

        [HttpGet("name")]
        [ActionName(nameof(GetIngredientByName))]
        public Ingredient GetIngredientByName(string name)
        {
            return _dataProvider.GetIngredientByName(name);
        }

        [HttpPost]
        public IActionResult InsertIngredient([FromBody] Ingredient ingredient)
        {
            _dataProvider.InsertIngredient(ingredient);
            return Ok();
        }

        [HttpPost]
        public IActionResult InsertRecipe([FromBody] Recipe recipe)
        {
            _dataProvider.InsertRecipe(recipe);
            return Ok();
        }

        [HttpDelete("id")]
        [ActionName(nameof(DeleteIngredient))]
        public IActionResult DeleteIngredient(int id)
        {
            _dataProvider.DeleteIngredient(id);
            return Ok();
        }

        [HttpDelete("id")]
        [ActionName(nameof(DeleteRecipe))]
        public IActionResult DeleteRecipe(int id)
        {
            _dataProvider.DeleteRecipe(id);
            return Ok();
        }
    }
}