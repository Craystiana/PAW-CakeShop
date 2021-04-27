using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Web.DataAccess.Entities
{
    [Table("ProductIngredient")]
    public class ProductIngredient
    {
        [Key]
        public int ProductIngredientId { get; set; }

        [Required]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public int IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}
