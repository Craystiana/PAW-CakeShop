using CakeShop.Web.Models.Product;
using CakeShop.Web.Models.ProductIngredient;
using CakeShop.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Enum = CakeShop.Web.Common.Enums;

namespace CakeShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductService _productService;
        private readonly IngredientService _ingredientService;

        public ProductController(ILogger<ProductController> logger, ProductService productService, IngredientService ingredientService)
        {
            _logger = logger;
            _productService = productService;
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public IActionResult List(int productType)
        {
            var model = new ProductListViewModel();

            var products = _productService.GetAllByType(productType);

            model.Products = products;
            model.PageProductTypeId = productType;

            switch (productType)
            {
                case (int) Enum.ProductType.Cake:
                    model.PageTitle = "Our Cakes";
                    break;
                case (int)Enum.ProductType.Drink:
                    model.PageTitle = "Our Drinks";
                    break;
                case (int)Enum.ProductType.Coffee:
                    model.PageTitle = "Our Coffee";
                    break;
            }

            return View("~/Views/Product/ProductList.cshtml", model);
        }

        public IActionResult Details(int productId)
        {
            var product = _productService.GetProduct(productId);

            return View("~/Views/Product/ProductDetails.cshtml", product);
        }

        [HttpGet]
        public IActionResult Add(int productType)
        {
            var model = new ProductViewModel 
            { 
                ProductTypeId = productType
            };

            return View("~/Views/Product/Add.cshtml", model);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel model)
        {
            _productService.Add(model);
            return RedirectToAction("List", "Product", new { productType = model.ProductTypeId});
        }

        [HttpGet]
        public IActionResult AddProductIngredient(int productId)
        {
            var model = new ProductIngredientViewModel
            {
                ProductId = productId
            };

            return View("~/Views/Product/AddProductIngredient.cshtml", model);
        }

        [HttpPost]
        public IActionResult AddProductIngredient(ProductIngredientViewModel model)
        {
            var ingredient = _ingredientService.GetIngredient(model.IngredientName);

            if (ingredient == null)
            {
                ingredient = _ingredientService.Add(model.IngredientName);
            }

            _productService.AddIngredient(model.ProductId, ingredient.IngredientId, model.Quantity);

            return RedirectToAction("Details", new { productId = model.ProductId });

        }

        public IActionResult DeleteIngredient(int productId, int ingredientId)
        {
            _productService.DeleteProductIngredient(productId, ingredientId);
            return RedirectToAction("Details", new { productId = productId });
        }

        public IActionResult DeleteProduct(int productId, int productTypeId)
        {
            _productService.DeleteProduct(productId);
            return RedirectToAction("List", new { productType = productTypeId });
        }
    }
}
