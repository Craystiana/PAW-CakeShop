using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeShop.Web.DataAccess.Entities
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public string ClientId { get; set; }

        public virtual User Client { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        public virtual User Employee { get; set; }

        public DateTime? OrderDate { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
