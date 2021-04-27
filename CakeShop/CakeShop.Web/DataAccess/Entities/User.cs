using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Web.DataAccess.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public int UserRoleId { get; set; }

        public virtual UserRole UserRole { get; set; }
        
        [ForeignKey("ClientId")]
        public virtual ICollection<Order> ClientOrders { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual ICollection<Order> EmployeeOrders { get; set; }
    }
}
