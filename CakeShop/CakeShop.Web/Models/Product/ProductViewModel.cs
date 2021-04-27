using CakeShop.Web.Models.Ingredient;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CakeShop.Web.Models.Product
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Product Price")]
        public int ProductPrice { get; set; }

        public int ProductTypeId { get; set; }

        [Display(Name = "Product Image")]
        public IFormFile ProductImage { get; set; }

        public byte[] Photo { get; set; }

        public ICollection<IngredientViewModel> Ingredients { get; set; }
    }
}
