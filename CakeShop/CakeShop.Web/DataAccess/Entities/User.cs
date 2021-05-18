using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeShop.Web.DataAccess.Entities
{
    [Table("User")]
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        public string Address { get; set; }

        public byte[] Photo { get; set; }
        
        [ForeignKey("ClientId")]
        public virtual ICollection<Order> ClientOrders { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual ICollection<Order> EmployeeOrders { get; set; }
    }
}
