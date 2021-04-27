using CakeShop.Web.Models.Product;
using CakeShop.Web.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CakeShop.Web.Models.Order
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        public int ClientId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime? OrderDate { get; set; }

        public ICollection<OrderItemViewModel> Products { get; set; }

        public UserViewModel Employee { get; set; }

        public UserViewModel Customer { get; set; }
    }
}
