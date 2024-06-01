using Microsoft.EntityFrameworkCore;
using PersonalCookBook.Domain.ProductAggregate;

namespace PersonalCookBook.Database.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product[]> GetProductsByIdsAsync(int[] productIds, CancellationToken cancellationToken);
    }

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(PersonalCookBookDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Product[]> GetProductsByIdsAsync(int[] productIds, CancellationToken cancellationToken)
        {
            return await Query()
                .Where(p => productIds.Any(i => i == p.Id))
                .ToArrayAsync(cancellationToken);
        }
    }
}
