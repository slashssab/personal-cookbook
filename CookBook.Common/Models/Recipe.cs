using System.Collections.Generic;

namespace Cookbook.Common.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public int DescriptionID { get; set; }
        public string Name { get; set; }
        public List<CookBookItem> CookBookItems {get; set;}
        public Description Description {get; set;}
    }
}