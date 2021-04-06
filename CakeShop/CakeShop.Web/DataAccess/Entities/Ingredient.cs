using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeShop.Web.DataAccess.Entities
{
    [Table("Ingredient")]
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }
    }
}
