using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Web.DataAccess.Entities
{
    [Table("UserRole")]
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
