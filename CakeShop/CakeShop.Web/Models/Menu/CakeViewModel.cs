using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CakeShop.Web.Models.Menu
{
    public class CakeViewModel
    {
        [Required]
        [Display(Name = "Cake Name")]
        public string CakeName { get; set; }

        [Required]
        [Display(Name = "Cake Price")]
        public double CakePrice { get; set; }

        [Required]
        [Display(Name = "Cake Image")]
        public IFormFile CakeImage { get; set; }
    }
}
