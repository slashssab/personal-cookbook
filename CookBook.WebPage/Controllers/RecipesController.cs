using Microsoft.AspNetCore.Mvc;
using Cookbook.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.WebPage.Controllers
{
    public class RecipesController : Controller
    {
        public async Task<ActionResult> Index()
        {
            IEnumerable<Recipe> AllIngredients = await Helpers.CookBookReciver.GetAllRecipes();
            return View(AllIngredients);     
        }
    }
}