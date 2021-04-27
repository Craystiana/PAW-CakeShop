using System.ComponentModel.DataAnnotations;

namespace CakeShop.Web.Models.ProductIngredient
{
    public class ProductIngredientViewModel
    {
        public int ProductId { get; set; }

        public string IngredientName { get; set; }

        public int Quantity { get; set; }
    }
}
