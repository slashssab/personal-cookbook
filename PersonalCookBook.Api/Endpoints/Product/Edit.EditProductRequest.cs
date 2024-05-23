using FastEndpoints;

namespace PersonalCookBook.Api.Endpoints.Product
{
    public class EditProductRequest
    {
        public const string Route = "api/Product/{id:int}/edit";

        [QueryParam]
        public int Id { get; init; }
        public string Name { get; init; }
        public double Kilocalories { get; init; }
        public double Proteins { get; init; }
        public double Carbohydrates { get; init; }
    }
}
