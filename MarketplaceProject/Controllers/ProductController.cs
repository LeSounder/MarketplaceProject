//Добавить в методах действий проверку на statusCode и перенаправлением на вьюшку с ошибкой

using Marketplace.Service.Interfaces;
using MarketplaceProject.Domain.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace MarketplaceProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;

        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var response = _productService.GetProducts();
            return View(response.Data);
        }

        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            var response = _productService.GetProduct(id);
            return View(response.Data);
        }


        [Authorize(Roles = "admin")]
        public IActionResult DeleteProduct(int id)
        {
            var response = _productService.DeleteProduct(id);
            return RedirectToAction("GetProducts");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult SaveProduct(int id)
        {
            if(id == 0)
            {
                return View();
            }

            var response = _productService.GetProduct(id);
            return View(response.Data);
        }

        [HttpPost]
        public IActionResult SaveProduct(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                if (productViewModel.Id == 0)
                {
                    _productService.Create(productViewModel);
                }
                else
                {
                    _productService.Edit(productViewModel);
                }
            }

            return RedirectToAction("GetProducts");  
        }
    }
}
