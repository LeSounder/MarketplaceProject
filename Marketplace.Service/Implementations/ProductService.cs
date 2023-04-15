using Marketplace.Service.Interfaces;
using MarketplaceProject.DAL.Interfaces;
using MarketplaceProject.Domain.Entities;
using MarketplaceProject.Domain.Response;
using MarketplaceProject.Domain.Enum;
using MarketplaceProject.Domain.ViewModels.Product;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> _productRepository;
        public ProductService(IBaseRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IBaseResponse<ProductViewModel> GetProduct(long id)
        {
            try
            {
                var product = _productRepository.Select().FirstOrDefault(x => x.Id == id);
                if (product == null)
                {
                    return new BaseResponse<ProductViewModel>()
                    {
                        Description = "Элемент",
                        StatusCode = StatusCode.NotFound
                    };
                }

                var data = new ProductViewModel()
                {
                    Name = product.Name,
                    Category = product.Category,
                    Price = product.Price,
                    Description = product.Description,
                };

                return new BaseResponse<ProductViewModel>()
                {
                    StatusCode = StatusCode.OK,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ProductViewModel>()
                {
                    Description = $"[GetProduct] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public BaseResponse<Dictionary<long, string>> GetProduct(string term)
        {
            var baseResponse = new BaseResponse<Dictionary<long, string>>();
            try
            {
                var products = _productRepository.Select()
                    .Select(x => new ProductViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Category = x.Category,
                        Price = x.Price,
                        Description = x.Description,
                    })
                    .Where(x => EF.Functions.Like(x.Name, $"%{term}%"))
                    .ToDictionary(x => x.Id, t => t.Name);

                baseResponse.Data = products;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dictionary<long, string>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public IBaseResponse<Product> Create(ProductViewModel productViewModel)
        {
            try
            {
                var product = new Product()
                {    
                    Name = productViewModel.Name,
                    Category = (Category)Convert.ToInt32(productViewModel.Category),
                    Price = productViewModel.Price,
                    Description = productViewModel.Description,

                }; 
                _productRepository.Create(product);

                return new BaseResponse<Product>()
                {
                    StatusCode = StatusCode.OK,
                    Data = product
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Product>()
                {
                    Description = $"[Create] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public IBaseResponse<bool> DeleteProduct(long id)
        {
            try
            {
                var product = _productRepository.Select().FirstOrDefault(x => x.Id == id);
                if (product == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "Элемент не найден",
                        StatusCode = StatusCode.NotFound,
                        Data = false
                    };
                }

                _productRepository.Delete(product);

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteProduct] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public IBaseResponse<Product> Edit(ProductViewModel productViewModel)
        {
            try
            {
                var product = _productRepository.Select().FirstOrDefault(x => x.Id == productViewModel.Id);
                if (product == null)
                {
                    return new BaseResponse<Product>()
                    {
                        Description = "",
                        StatusCode = StatusCode.NotFound
                    };
                }

                product.Name = productViewModel.Name;
                product.Description = productViewModel.Description;
                product.Price = productViewModel.Price;

                _productRepository.Update(product);


                return new BaseResponse<Product>()
                {
                    Data = product,
                    StatusCode = StatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Product>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public IBaseResponse<List<Product>> GetProducts()
        {
            try
            {
                var products = _productRepository.Select().ToList();
                if (!products.Any())
                {
                    return new BaseResponse<List<Product>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }
                
                return new BaseResponse<List<Product>>()
                {
                    Data = products,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Product>>()
                {
                    Description = $"[GetProducts] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
