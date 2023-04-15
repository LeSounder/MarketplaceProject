using MarketplaceProject.Domain.Entities;
using MarketplaceProject.Domain.Response;
using MarketplaceProject.Domain.ViewModels.Product;

namespace Marketplace.Service.Interfaces
{
    public interface IProductService
    {
        IBaseResponse<List<Product>> GetProducts();

        IBaseResponse<ProductViewModel> GetProduct(long id);

        BaseResponse<Dictionary<long, string>> GetProduct(string term);

        IBaseResponse<Product> Create(ProductViewModel product);

        IBaseResponse<bool> DeleteProduct(long id);

        IBaseResponse<Product> Edit(ProductViewModel model);
    }
}
