using Microsoft.AspNetCore.Mvc;
using Cookbook.Common.Models;
using System.Collections.Generic;

namespace CookBook.WebPage.Controllers
{
    public class IngredientsController : Controller
    {
        public IActionResult Index()
        {
            return View(_getIngredients());
        }

        private List<Ingredient> _getIngredients()
        {
            return new List<Ingredient> 
            {
                new Ingredient
                {
                    Id = 1,
                    Name = "Test_1",
                    Kcal100 = 100
                },
                new Ingredient
                {
                    Id = 2,
                    Name = "Test_1",
                    Kcal100 = 100
                }
            };
        }
    }
}