using System.Collections.Generic;
using CookBook.WebPage.Models;

namespace CookBook.WebPage.Constants
{
    public class Templates
    {
        public static RecipeViewModel RecipeToBeAddedTemplate = new RecipeViewModel
        {
            Name = "New Ingredient",
            CookBookItems  = new List<CookBookItemViewModel>(),
            Description = "Description",
            Calories = 0
        };
    }
}