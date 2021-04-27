using CakeShop.Web.DataAccess.Entities;
using CakeShop.Web.DataAccess.Repository;
using CakeShop.Web.Models.Ingredient;
using CakeShop.Web.Models.Product;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CakeShop.Web.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly IRepository<ProductIngredient> _productIngredientRepository;
        private readonly IRepository<Ingredient> _ingredientRepository;

        public ProductService(IRepository<Product> productRepository, IRepository<ProductIngredient> productIngredientRepository, IRepository<Ingredient> ingredientRepository)
        {
            _productRepository = (ProductRepository)productRepository;
            _productIngredientRepository = productIngredientRepository;
            _ingredientRepository = ingredientRepository;
        }

        public ProductViewModel GetProduct(int productId)
        {
            var product = _productRepository.GetProductWithIngredients(productId);
            var productIngredients = product.ProductIngredients;
            var model = new ProductViewModel
            {
                ProductId = product.ProductId,
                ProductName = product.Name,
                ProductPrice = product.Price,
                ProductTypeId = product.ProductTypeId,
                Photo = product.Photo,
                Ingredients = new List<IngredientViewModel>()
            };

            if (productIngredients != null)
            {
                foreach (var productIngredient in productIngredients)
                {
                    model.Ingredients.Add(new IngredientViewModel
                    {
                        IngredientId = productIngredient.IngredientId,
                        IngredientName = productIngredient.Ingredient.Name,
                        Quantity = productIngredient.Quantity
                    });
                }
            }

            return model;
        }

        public IEnumerable<ProductViewModel> GetAllByType(int productType)
        {
            var products = _productRepository.Find(product => product.ProductTypeId == productType);

            foreach (var product in products)
            {
                yield return new ProductViewModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    Photo = product.Photo
                };
            }
        }

        public void Add(ProductViewModel model)
        {
            var product = new Product
            {
                Name = model.ProductName,
                Price = model.ProductPrice,
                ProductTypeId = model.ProductTypeId
            };

            using (var stream = new BinaryReader(model.ProductImage.OpenReadStream()))
            {
                product.Photo = stream.ReadBytes((int)model.ProductImage.Length);
            }

            _productRepository.Add(product);
            _productRepository.SaveChanges();
        }

        public void AddIngredient (int productId, int ingredientId, int quantity)
        {
            _productIngredientRepository.Add(new ProductIngredient
            {
                ProductId = productId,
                IngredientId = ingredientId,
                Quantity = quantity
            });

            _productIngredientRepository.SaveChanges();
        }
        
        public void DeleteProductIngredient(int productId, int ingredientId)
        {
            var product = _productRepository.GetProductWithIngredients(productId);
            var productIngredient = product.ProductIngredients.SingleOrDefault(pi => pi.IngredientId == ingredientId);

            _productIngredientRepository.Remove(productIngredient);
            _productIngredientRepository.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            _productRepository.Remove(_productRepository.Get(productId));
            _productRepository.SaveChanges();
        }
    }
}
