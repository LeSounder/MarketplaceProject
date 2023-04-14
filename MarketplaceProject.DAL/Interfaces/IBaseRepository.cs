namespace MarketplaceProject.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        bool Create(T entity);
        T Get(long id);
        IEnumerable<T> Select();
        bool Delete(T entity);
        T Update(T entity);
    }
}
