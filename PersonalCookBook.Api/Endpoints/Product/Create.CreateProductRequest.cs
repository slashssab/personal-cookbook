using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Api.Endpoints.Product
{
    public class CreateProductRequest
    {
        public const string Route = "api/Product";

        public string Name { get; init; }
        public double Kilocalories { get; init; }
        public double Proteins { get; init; }
        public double Carbohydrates { get; init; }
    }
}
