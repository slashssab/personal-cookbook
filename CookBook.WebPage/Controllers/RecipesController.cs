using Microsoft.AspNetCore.Mvc;
using Cookbook.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CookBook.WebPage.Helpers;

namespace CookBook.WebPage.Controllers
{
    public class RecipesController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.Ingredients = new List<string>
            {
                "Chinken",
                "honey"
            };
            IEnumerable<Recipe> AllIngredients = await Helpers.CookBookReciver.GetAllRecipes();
            return View(AllIngredients);     
        }

        public ActionResult RecipesList()
        {
            return PartialView("RecipesList");
        }

        [HttpPost]
        public async Task<ActionResult> CreateRecipe(Recipe recipe)
        {
            await Helpers.CookBookExporter.InsertRecipe(recipe);
            return RedirectToAction("Index", "Recipes");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int Id)
        {
            await Helpers.CookBookCleanner.DeleteRecipe(Id);
            return RedirectToAction("Index", "Recipes");
        }

        [HttpGet]
        public async Task<ActionResult> ShowRecipe(int Id)
        {
            var recipe = await Helpers.CookBookReciver.GetRecipeById(Id);
            var viewModel = ViewModelMapper.MapToViewModel(recipe);
            return View("RecipeView", viewModel);  
        }
    }
}