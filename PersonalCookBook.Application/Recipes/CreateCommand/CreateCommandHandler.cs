using MediatR;
using PersonalCookBook.Database.Repositories;
using PersonalCookBook.Domain.RecipeAggregate;
using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Application.Recipes.CreateCommand
{
    public class CreateCommandHandler(IRepository<Recipe> _recipeRepository) : IRequestHandler<CreateCommand, RecipeResource>
    {
        public async Task<RecipeResource> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var newRecipe = Recipe.Create(
                request.Name,
                request.Description,
                request.Ingredients.Select(i => new Ingredient
                {
                    ProductId = i.Product.Id,
                    Quantity = i.Quantity,
                    Unit = Domain.RecipeAggregate.Enums.Unit.Gram
                }).ToArray(),
                request.Steps.Select(s => new Step
                {
                    Order = s.Order,
                    Content = s.Content
                }).ToArray());

            await _recipeRepository.AddAsync(newRecipe);
            await _recipeRepository.SaveChangesAsync();

            return new RecipeResource(newRecipe.Id, request.Name, newRecipe.Description,request.Ingredients, request.Steps);
        }
    }
}
