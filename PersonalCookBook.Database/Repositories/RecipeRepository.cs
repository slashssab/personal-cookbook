using Microsoft.EntityFrameworkCore;
using PersonalCookBook.Domain.RecipeAggregate;

namespace PersonalCookBook.Database.Repositories
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<Recipe?> GetRecipeAggregateAsync(int id, CancellationToken cancellationToken);
    }

    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(PersonalCookBookDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Recipe?> GetRecipeAggregateAsync(int id, CancellationToken cancellationToken)
        {
            return await Query(true)
                .Include(r => r.Ingredients).ThenInclude(r => r.Product)
                .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        }
    }
}
