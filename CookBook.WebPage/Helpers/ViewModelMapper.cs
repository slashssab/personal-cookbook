using System;
using System.Collections.Generic;
using Cookbook.Common;
using Cookbook.Common.Models;
using CookBook.WebPage.Models;
using CookBook.WebPage.Utils;

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
                Id = recipe.Id,
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

        public static IEnumerable<RecipeViewModel> MapToViewModel(IEnumerable<Recipe> recipes)
        {
            var recipesViewmodel = new List<RecipeViewModel>();
            foreach(var recipe in recipes)
            {
                recipesViewmodel.Add(MapToViewModel(recipe));
            }
            return recipesViewmodel;
        }

        public static CookBookItem MapToModel(CookBookItemViewModel cookBookItemViewModel)
        {
            return new CookBookItem
            {
                Quantity = cookBookItemViewModel.Quantity,
                IngredientId = GetIngredientId(cookBookItemViewModel.Ingredient),
                Unit = (Unit)System.Enum.Parse(typeof(Unit), cookBookItemViewModel.Unit)
            };
        }

        public static Recipe MapToModel(RecipeViewModel recipeViewModel)
        {
            var cookBookItems = new List<CookBookItem>();
            foreach(var cookBookItem in recipeViewModel.CookBookItems)
            {
                cookBookItems.Add(MapToModel(cookBookItem));
            }

            return new Recipe
            {
                Name = recipeViewModel.Name,
                Description = new Description{ Text = recipeViewModel.Description },
                CookBookItems = cookBookItems
            };
        }

        public static int GetIngredientId(string ingredientName)
        {
            return CookBookData.GetIngredientIdByName(ingredientName).Id;
        }
    }
}