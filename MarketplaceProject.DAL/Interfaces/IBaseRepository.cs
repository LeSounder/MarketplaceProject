namespace MarketplaceProject.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        bool Create(T entity);
        IQueryable<T> Select();
        bool Delete(T entity);
        T Update(T entity);
    }
}
