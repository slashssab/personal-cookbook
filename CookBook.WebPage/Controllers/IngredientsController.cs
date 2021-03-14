using Microsoft.AspNetCore.Mvc;
using Cookbook.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace CookBook.WebPage.Controllers
{
    public class IngredientsController : Controller
    {
        public async Task<ActionResult> Index()
        {
            IEnumerable<Ingredient> ingredientsList = await Helpers.CookBookReciver.GetAlIngredients();
            return View("Index", ingredientsList);
        }

        public ActionResult IngredientsList()
        {
            return PartialView("IngredientsList");
        }

        [HttpPost]
        public async Task<ActionResult> CreateIngredient(Ingredient ingredient)
        {
            await Helpers.CookBookExporter.InsertIngredient(ingredient);
            return RedirectToAction("Index", "Ingredients");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int Id)
        {
            await Helpers.CookBookCleanner.DeleteIngredient(Id);
            return RedirectToAction("Index", "Ingredients");
        }
    }
}