using MarketplaceProject.Domain.Entities;
using MarketplaceProject.Domain.Response;
using MarketplaceProject.Domain.ViewModels.Product;

namespace Marketplace.Service.Interfaces
{
    public interface IProductService
    {
        public IBaseResponse<IEnumerable<Product>> GetProducts();
        public IBaseResponse<Product> GetProduct(long id);
        public IBaseResponse<Product> GetProductByName(string name);
        public IBaseResponse<bool> DeleteProduct(long id);
        public IBaseResponse<ProductViewModel> CreateProduct(ProductViewModel productViewModel);
        public IBaseResponse<Product> EditProduct(ProductViewModel productViewModel);
    }
}
