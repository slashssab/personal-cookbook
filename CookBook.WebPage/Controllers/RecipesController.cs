using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using CookBook.WebPage.Helpers;
using CookBook.WebPage.Models;
using CookBook.WebPage.Constants;
using System;
using CookBook.WebPage.Utils;
using System.Globalization;

namespace CookBook.WebPage.Controllers
{
    public class RecipesController : Controller
    {
        private static RecipePartialViewModel _recipesPartialViewModel= new RecipePartialViewModel();
        public async Task<ActionResult> Index()
        {
            var allRecipes = await Helpers.CookBookReciver.GetAllRecipes();
            var allIngredients = await CookBookData.GetIngredientsCollection();
            ViewBag.Ingredients = allIngredients.Select(i => i.Name);
            _recipesPartialViewModel.RecipesList = ViewModelMapper.MapToViewModel(allRecipes);
            _recipesPartialViewModel.RecipeTobeAdded = Templates.RecipeToBeAddedTemplate;
            return View(_recipesPartialViewModel);     
        }

        public ActionResult RecipesList()
        {
            return PartialView("RecipesList");
        }

        [HttpPost]
        public async Task<ActionResult> CreateRecipe(RecipeViewModel recipe)
        {
            _recipesPartialViewModel.RecipeTobeAdded.Description = recipe.Description;
            _recipesPartialViewModel.RecipeTobeAdded.Name = recipe.Name;

            var recipeModel = ViewModelMapper.MapToModel(_recipesPartialViewModel.RecipeTobeAdded);
            await Helpers.CookBookExporter.InsertRecipe(recipeModel);
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

        [HttpPost]
        public async Task<ActionResult> AddIngredient()
        {
            var ingredient = Request.Form[StringConstants.SelectedIngredientName].ToString();
            var quantity = float.Parse(Request.Form[StringConstants.SelectedQuantityName].ToString(), CultureInfo.InvariantCulture.NumberFormat);
            var unit = Request.Form[StringConstants.SelectedUnitName].ToString();
            var kcal100 = (await Helpers.CookBookReciver.GetIngredientByName(ingredient)).Kcal100;
            _recipesPartialViewModel.RecipeTobeAdded.CookBookItems.Add(
                new CookBookItemViewModel
                {
                    Ingredient = ingredient,
                    Quantity = quantity,
                    Unit = unit,
                    Kcal100 = kcal100
                }
            );
            return RedirectToAction("Index", "Recipes",  _recipesPartialViewModel);
        }
    }
}