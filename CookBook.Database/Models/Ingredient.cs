namespace CookBook.Database.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Kcal100 { get; set; }

        public List<CookBookItem> CookBookItems { get; set; }
    }
}
