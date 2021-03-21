using System.Collections.Generic;

namespace CookBook.WebPage.Models
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CookBookItemViewModel> CookBookItems {get; set;}
        public string Description {get; set;}
        public double Calories {get; set;}
    }
}