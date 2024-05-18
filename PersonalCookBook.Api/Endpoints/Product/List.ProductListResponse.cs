using PersonalCookBook.Resources.Product;

namespace PersonalCookBook.Api.Endpoints.Product
{
    public class ProductListResponse
    {
        public ProductResource[] Products { get; init; } = [];
    }
}
