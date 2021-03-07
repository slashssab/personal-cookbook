using Microsoft.AspNetCore.Mvc;
using Cookbook.Common.Models;
using System.Collections.Generic;
using Cookbook.DAL.EF;
using Cookbook.WebApi.Helpers;

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
        [ActionName(nameof(GetCookBookItemsById))]
        public CookBookItem GetCookBookItemsById(int id)
        {
            return _repositoryHelper.GetCookBookItem(id);
        }

        [HttpPost]
        public IActionResult InsertIngredient([FromBody] Ingredient ingredient)
        {
            _repositoryHelper.InsertIngredient(ingredient);
            return Ok();
        }

        [HttpDelete("id")]
        [ActionName(nameof(DeleteIngredient))]
        public IActionResult DeleteIngredient(int id)
        {
            _repositoryHelper.DeleteIngredient(id);
            return Ok();
        }
    }
}