using MediatR;
using PersonalCookBook.Resources.Product;
using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Application.Recipes.GetRecipeByIdQuery
{
    public class GetRecipeByIdQueryHandler : IRequestHandler<GetRecipeByIdQuery, RecipeResource>
    {
        public async Task<RecipeResource> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(500);
            var ingredients = new IngredientResource[]
            {
                new IngredientResource(new ProductResource(1, "Product Name", 230, 23, 10), 200)
            };
            return new RecipeResource(request.Id, "Recipe Title", ingredients, []);
        }
    }
}
