using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Web.DataAccess.Entities
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public virtual User Client { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public virtual User Employee { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
