using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Web.DataAccess.Entities
{
    [Table("OrderItem")]
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public virtual Order Order { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public virtual Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
