using MediatR;
using PersonalCookBook.Database.Repositories;
using PersonalCookBook.Domain.ProductAggregate;
using PersonalCookBook.Domain.RecipeAggregate;
using PersonalCookBook.Resources.Product;
using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Application.Recipes.EditRecipeCommand
{
    public class EditRecipeCommandHandler(IRecipeRepository _recipeRepository, IProductRepository _productRepository) : IRequestHandler<EditRecipeCommand, RecipeResource>
    {
        public async Task<RecipeResource> Handle(EditRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRepository.GetRecipeAggregateAsync(request.Id, cancellationToken);
            
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }

            recipe.UpdateName(request.Name);
            recipe.UpdateDescription(request.Description);
            recipe.UpdateIngredients(request.Ingredients.Select(i => new Ingredient
            {
                ProductId = i.Product.Id,
                Quantity = i.Quantity,
                Unit = i.Unit
            }).ToArray());

            recipe.UpdateIngredients(request.Ingredients.Select(i => new Ingredient
            {
                ProductId = i.Product.Id,
                Quantity = i.Quantity,
                Unit = i.Unit
            }).ToArray());

            recipe.UpdateSteps(request.Steps.Select(s => new Step
            {
                Id = s.Id,
                Content = s.Content,
                Type = s.Type,
                Order = s.Order,
            }).ToArray());

            await _recipeRepository.SaveChangesAsync();
            var products = await _productRepository.GetProductsByIdsAsync(recipe.Ingredients.Select(i => i.ProductId).ToArray(), cancellationToken);

            var ingredients = MapIngredients(recipe.Ingredients.ToArray(), products.ToArray());
            var steps = recipe.Steps.Select(s =>
                 new StepResource(
                    s.Id,
                    s.Order,
                    s.Content,
                    s.Type
                )
            ).ToArray();

            return new RecipeResource(recipe.Id, recipe.Name, recipe.Description,ingredients, steps);
        }

        private IngredientResource[] MapIngredients(Ingredient[] Ingredients, Product[] products)
        {
            var mappedIngredients = Ingredients.Select(i => new IngredientResource(
                     new ProductResource(
                                    products.First(p => p.Id == i.ProductId).Id,
                                    products.First(p => p.Id == i.ProductId).Name,
                                    products.First(p => p.Id == i.ProductId).Kcal,
                                    products.First(p => p.Id == i.ProductId).Protein,
                                    products.First(p => p.Id == i.ProductId).Carbs)
                                ,
                    i.Quantity,
                    i.Unit
                )).ToArray();

            return mappedIngredients;
        }
    }
}
