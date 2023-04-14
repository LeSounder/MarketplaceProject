using Marketplace.Service.Interfaces;
using MarketplaceProject.DAL.Interfaces;
using MarketplaceProject.Domain.Entities;
using MarketplaceProject.Domain.Response;
using MarketplaceProject.Domain.Enum;
using MarketplaceProject.Domain.ViewModels.Product;
using System;

namespace Marketplace.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }



        public IBaseResponse<Product> GetProduct(long id)
        {
            var baseResponse = new BaseResponse<Product>();

            try
            {
                var product = _productRepository.Get(id);
                if (product == null)
                {
                    baseResponse.Description = "Element not found";
                    baseResponse.statusCode = StatusCode.NotFound;
                    return baseResponse;
                }

                baseResponse.Data = product;
                return baseResponse;
            }
            catch (Exception exception)
            {
                return new BaseResponse<Product>()
                {
                    Description = $"[GetProduct] : {exception.Message}",
                    statusCode = StatusCode.InternalServerError
                };
            }
        }
        public IBaseResponse<bool> DeleteProduct(long id)
        {
            var baseResponse = new BaseResponse<bool>();

            try
            {
                var product = _productRepository.Get(id);

                if (product == null)
                {
                    baseResponse.Description = "Element not found";
                    baseResponse.statusCode = StatusCode.NotFound;

                    return baseResponse;
                }

                _productRepository.Delete(product);
                return baseResponse;

            }
            catch (Exception exception)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteProduct] : {exception.Message}",
                    statusCode = StatusCode.InternalServerError
                };
            }
        }

        public IBaseResponse<ProductViewModel> CreateProduct(ProductViewModel productViewModel)
        {
            var baseResponse = new BaseResponse<ProductViewModel>();

            try
            {
                var product = new Product()
                {
                    Name = productViewModel.Name,
                    Category = productViewModel.Category,
                    Price = productViewModel.Price,
                    Description = productViewModel.Description,
                    DateCreate = productViewModel.DateCreate,
                    
                };

                _productRepository.Create(product);

            }
            catch (Exception exception)
            {
                return new BaseResponse<ProductViewModel>()
                {
                    Description = $"[CreateProduct] : {exception.Message}",
                    statusCode = StatusCode.InternalServerError
                };
            }

            return baseResponse;
        }

        public IBaseResponse<Product> GetProductByName(string name)
        {
            var baseResponse = new BaseResponse<Product>();

            try
            {
                var product = _productRepository.GetByName(name);
                if (product == null)
                {
                    baseResponse.Description = "Element not found";
                    baseResponse.statusCode = StatusCode.NotFound;
                    return baseResponse;
                }

                baseResponse.Data = product;
                return baseResponse;
            }
            catch (Exception exception)
            {
                return new BaseResponse<Product>()
                {
                    Description = $"[GetProduct] : {exception.Message}",
                    statusCode = StatusCode.InternalServerError
                };
            }
        }

        public IBaseResponse<Product> EditProduct(ProductViewModel productViewModel)
        {
            var baseResponse = new BaseResponse<Product>();
            try
            {
                var product = _productRepository.Get(productViewModel.Id);
                if (product == null)
                {
                    baseResponse.statusCode = StatusCode.NotFound;
                    baseResponse.Description = "Element not found";

                    return baseResponse;
                }

                product.Description = productViewModel.Description;
                product.Name = productViewModel.Name;

                _productRepository.Update(product);

                return baseResponse;
            }
            catch (Exception exception)
            {
                return new BaseResponse<Product>()
                {
                    Description = $"[EditProduct] : {exception.Message}",
                    statusCode = StatusCode.InternalServerError
                };
            }
        }

        public IBaseResponse<IEnumerable<Product>> GetProducts()
        {
            var baseResponse = new BaseResponse<IEnumerable<Product>>();
            try
            {
                var products = _productRepository.Select();

                if (products.Count() == 0)
                {
                    baseResponse.Description = "Elements not found";
                    baseResponse.statusCode = StatusCode.NotFound;
                }

                baseResponse.Data = products;
                baseResponse.statusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception exception)
            {
                return new BaseResponse<IEnumerable<Product>>()
                {
                    Description = $"[GetProducts] : {exception.Message}",
                    statusCode = StatusCode.InternalServerError
                    
                };
            }
        }   
    }
}
