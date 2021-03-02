using Microsoft.AspNetCore.Mvc;
using Cookbook.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.WebPage.Controllers
{
    public class IngredientsController : Controller
    {
        public async Task<ActionResult> Index()
        { 
            IEnumerable<Ingredient> ingredientsList = await Helpers.CookBookReciver.GetAlIngredients();
            return View("Index", ingredientsList);     
        }
 
        public ActionResult ngredientsList()
        {
            return PartialView("IngredientsList");  
        }

        [HttpPost]
        public async Task<ActionResult> CreateIngredient(Ingredient ingredient)
        {
            await Helpers.CookBookExporter.InsertIngredient(ingredient);
            return RedirectToAction("Index", "Ingredients");
        }
    }
}