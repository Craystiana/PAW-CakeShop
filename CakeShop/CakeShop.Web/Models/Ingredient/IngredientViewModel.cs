using System.ComponentModel.DataAnnotations;

namespace CakeShop.Web.Models.Ingredient
{
    public class IngredientViewModel
    {
        public int IngredientId { get; set; }

        [Required]
        public string IngredientName { get; set; }

        public int Quantity { get; set; }
    }
}
