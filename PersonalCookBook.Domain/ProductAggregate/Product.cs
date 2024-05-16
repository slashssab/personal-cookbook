namespace PersonalCookBook.Domain.ProductAggregate
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Kcal {  get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
    }
}
