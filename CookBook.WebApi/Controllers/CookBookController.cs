using Microsoft.AspNetCore.Mvc;
using Cookbook.Common.Models;
using System.Collections.Generic;
using Cookbook.DAL.EF;
using Cookbook.WebApi.Helpers;
using System.Linq;

namespace Cookbook.Controllers
{
    [ApiController]
    [Route("_api/cookbookitems/[Action]")]
    public class CookBookController : ControllerBase
    {
        private readonly RepositoriesHelper _repositoryHelper;
        public CookBookController(CookbookContext context)
        {
            _repositoryHelper = new RepositoriesHelper(context);
        }

        [HttpGet]
        [ActionName(nameof(GetAllIngredients))]
        public IEnumerable<Ingredient> GetAllIngredients()
        {
            return _repositoryHelper.GetAllIngredients();
        }

        [HttpGet]
        [ActionName(nameof(GetAllRecipes))]
        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _repositoryHelper.GetAllRecipes();
        }

        [HttpGet("id")]
        [ActionName(nameof(GetCookBookItemById))]
        public CookBookItem GetCookBookItemById(int id)
        {
            return _repositoryHelper.GetCookBookItem(id);
        }

        [HttpGet("id")]
        [ActionName(nameof(GetRecipeById))]
        public Recipe GetRecipeById(int id)
        {
            return _repositoryHelper.GetRecipeById(id);
        }

        [HttpGet("name")]
        [ActionName(nameof(GetIngredientByName))]
        public Ingredient GetIngredientByName(string name)
        {
            return _repositoryHelper.GetIngredientByName(name);
        }

        [HttpPost]
        public IActionResult InsertIngredient([FromBody] Ingredient ingredient)
        {
            _repositoryHelper.InsertIngredient(ingredient);
            return Ok();
        }

        [HttpPost]
        public IActionResult InsertRecipe([FromBody] Recipe recipe)
        {
            _repositoryHelper.InsertRecipe(recipe);
            return Ok();
        }

        [HttpDelete("id")]
        [ActionName(nameof(DeleteIngredient))]
        public IActionResult DeleteIngredient(int id)
        {
            _repositoryHelper.DeleteIngredient(id);
            return Ok();
        }

        [HttpDelete("id")]
        [ActionName(nameof(DeleteRecipe))]
        public IActionResult DeleteRecipe(int id)
        {
            _repositoryHelper.DeleteRecipe(id);
            return Ok();
        }
    }
}