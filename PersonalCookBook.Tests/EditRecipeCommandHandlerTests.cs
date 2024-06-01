using Moq;
using PersonalCookBook.Application.Recipes.EditRecipeCommand;
using PersonalCookBook.Database.Repositories;
using PersonalCookBook.Domain.ProductAggregate;
using PersonalCookBook.Domain.RecipeAggregate;
using PersonalCookBook.Domain.RecipeAggregate.Enums;
using PersonalCookBook.Resources.Product;
using PersonalCookBook.Resources.Recipe;

namespace PersonalCookBook.Tests
{
    [TestClass]
    public class EditRecipeCommandHandlerTests : RequestHandlerTestBase<EditRecipeCommandHandler>
    {
        private EditRecipeCommandHandler _sut;
        private Recipe _initialRecipe;
        private Product[] _initialProducts;

        [TestInitialize]
        public void TestInitialize()
        {
            _initialRecipe = BuildInitialRecipe();
            _initialProducts = BuildInitialProducts();
            _sut = PrepareTestSubject();
        }

        [TestMethod]
        public async Task UpdateRecipe_UpdateRecipeName_ClearIngredients_ClearSteps()
        {
            var command = new EditRecipeCommand(0, "Edited name", "Edited description", [], []);
            var result = await _sut.Handle(command, default);
            Assert.AreEqual(command.Name, result.Name);
            Assert.AreEqual(result.Ingredients.Length, 0);
        }

        [TestMethod]
        public async Task UpdateRecipe_UpdateRecipeName_ReplaceIngredient_ClearSteps()
        {
            var newIngredients = new IngredientResource[]
            {
                new IngredientResource(
                    new ProductResource(2,"Replaced test product", 100, 20, 30),
                    100,
                    Unit.Gram
                    )
            };
            var command = new EditRecipeCommand(0, "Edited name", "Edited description", [], newIngredients);
            var result = await _sut.Handle(command, default);
            Assert.AreEqual(command.Name, result.Name);
            Assert.AreEqual(result.Ingredients.Length, 1);
        }

        private Recipe BuildInitialRecipe()
        {
            var ingredients = new List<Ingredient>
            {
                new Ingredient
                {
                    ProductId = 1,
                    Quantity = 100,
                    Unit = Unit.Gram,
                    Product = Product.CreateNew("Test product", 100, 20, 30)
                }
            };

            var steps = new List<Step>();

            return Recipe.Create("Test recipe", "Test recipe description", ingredients, steps);
        }

        private Product[] BuildInitialProducts()
        {
            var products = new Product[]
            {
               Product.CreateNew("Product 1", 100, 30, 40)
            };

            return products;
        }

        public override EditRecipeCommandHandler PrepareTestSubject()
        {
            var _recipeRepositoryMock = PrepareRecipeRepository(_initialRecipe);
            var _productRepositoryMock = PrepareProductRepository(_initialProducts);
            return new EditRecipeCommandHandler(_recipeRepositoryMock, _productRepositoryMock);
        }

        private IRecipeRepository PrepareRecipeRepository(Recipe initialRecipe)
        {
            var mockRepository = new Mock<IRecipeRepository>();
            mockRepository.Setup(r => r.GetRecipeAggregateAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(initialRecipe);
            return mockRepository.Object;
        }

        private IProductRepository PrepareProductRepository(Product[] initialProducts)
        {
            var mockRepository = new Mock<IProductRepository>();
            mockRepository.Setup(r => r.GetProductsByIdsAsync(It.IsAny<int[]>(), It.IsAny<CancellationToken>())).ReturnsAsync(initialProducts);
            return mockRepository.Object;
        }
    }
}