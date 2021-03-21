using System.Collections.Generic;

namespace CookBook.WebPage.Models
{
    public class RecipePartialViewModel
    {
        public IEnumerable<RecipeViewModel> RecipesList {get; set;}
        public RecipeViewModel RecipeTobeAdded {get; set;}
    }
}