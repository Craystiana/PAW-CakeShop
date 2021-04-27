using CakeShop.Web.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CakeShop.Web.DataAccess.Repository
{
    public class ProductRepository : Repository<Product> 
    {
        public ProductRepository(Context context) : base(context) { }

        public Product GetProductWithIngredients(int productId)
        {
           return _context.Products.Include(p => p.ProductIngredients)
                                   .ThenInclude(pi => pi.Ingredient)
                                   .FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
