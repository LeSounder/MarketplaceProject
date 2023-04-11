using MarketplaceProject.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var response = _productRepository.Select();
            return View(response);
        }
    }
}
