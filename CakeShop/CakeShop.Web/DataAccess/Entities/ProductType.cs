using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Web.DataAccess.Entities
{
    [Table("ProductType")]
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
