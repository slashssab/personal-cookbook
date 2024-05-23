namespace PersonalCookBook.Domain.ProductAggregate
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Kcal {  get; private set; }
        public double Protein { get; private set; }
        public double Carbs { get; private set; }

        public static Product CreateNew(string name,
            double kcal,
            double proteins,
            double carbohydrates)
        {
            return new Product
            {
                Name = name,
                Kcal = kcal,
                Protein = proteins,
                Carbs = carbohydrates
            };
        }

        public void UpdateName(string newName)
        {
            Name = newName;
        }
        public void UpdateCalories(double newValue)
        {
            Kcal = newValue;
        }

        public void UpdateProteins(double newValue)
        {
            Protein = newValue;
        }

        public void UpdateCarbohydrates(double newValue)
        {
            Carbs = newValue;
        }
    }
}
