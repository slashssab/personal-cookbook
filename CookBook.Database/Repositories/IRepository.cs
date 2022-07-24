namespace Cookbook.Database.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T item);
        void Delete(int id);
        IEnumerable<T> GetByQuery(Func<T, bool> query);
    }
}