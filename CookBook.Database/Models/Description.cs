namespace CookBook.Database.Models
{
    public class Description
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Recipe Recipe { get; set; }
    }
}
