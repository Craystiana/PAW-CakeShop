using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Web.DataAccess.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int ProductTypeId { get; set; }

        public virtual ProductType ProductType { get; set; }

        public byte[] Photo { get; set; }

        public virtual ICollection<ProductIngredient> ProductIngredients { get; set; }
    }
}
