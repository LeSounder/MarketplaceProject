using MarketplaceProject.Domain.Entities;

namespace MarketplaceProject.DAL.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Product GetByName(string name);
    }
}
