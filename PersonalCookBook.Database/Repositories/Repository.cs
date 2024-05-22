using Microsoft.EntityFrameworkCore;

namespace PersonalCookBook.Database.Repositories
{
    public class Repository<TClass> : IRepository<TClass>
            where TClass : class
    {
        protected readonly PersonalCookBookDbContext _dbContext;

        protected DbSet<TClass> DbSet => _dbContext.Set<TClass>();

        public Repository(PersonalCookBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TClass> Query(bool asTracking = false)
        {
            var query = DbSet.AsQueryable();
            return asTracking ? query.AsTracking() : query.AsNoTracking();
        }

        public async Task<TClass> AddAsync(TClass entity)
        {
            var entityEntry = await DbSet.AddAsync(entity);
            return entityEntry.Entity;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
