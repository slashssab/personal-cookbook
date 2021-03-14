using System;
using System.Collections.Generic;
using Cookbook.Common;
using Cookbook.Common.Models;
using CookBook.WebPage.Models;

namespace CookBook.WebPage.Helpers
{
    public class ViewModelMapper
    {
        public static RecipeViewModel MapToViewModel(Recipe recipe)
        {
            var cookBookItems = new List<CookBookItemViewModel>();
            var calories = 0.0;
            recipe.CookBookItems.ForEach(item =>
            {
                calories += item.Quantity * 0.01 * item.Ingredient.Kcal100;
                cookBookItems.Add(MapToViewModel(item));
            });

            return new RecipeViewModel
            {
                Name = recipe.Name,
                CookBookItems = cookBookItems,
                Description = recipe.Description.Text,
                Calories = calories
            };
        }

        public static CookBookItemViewModel MapToViewModel(CookBookItem cookBookItem)
        {
            return new CookBookItemViewModel
            {
                Quantity = cookBookItem.Quantity,
                Unit = Enum.GetName(typeof(Unit),cookBookItem.Unit),
                Ingredient = cookBookItem.Ingredient.Name,
                Kcal100 = cookBookItem.Ingredient.Kcal100
            };
        }
    }
}