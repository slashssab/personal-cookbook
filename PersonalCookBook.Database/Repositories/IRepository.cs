namespace PersonalCookBook.Database.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Query(bool asTracking = false);
        Task<TEntity> AddAsync(TEntity entity);
        Task SaveChangesAsync();
    }
}
