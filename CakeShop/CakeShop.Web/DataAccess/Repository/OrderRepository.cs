using CakeShop.Web.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CakeShop.Web.DataAccess.Repository
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(Context context) : base(context) { }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders.Include(p => p.Employee)
                                  .Include(p => p.Client)
                                  .Where(p => p.OrderDate != null);
        }

        public Order GetOrder(int orderId)
        {
            return _context.Orders.Include(p => p.Employee)
                                  .Include(p => p.Client)
                                  .Include(p => p.OrderItems)
                                  .ThenInclude(pi => pi.Product)
                                  .FirstOrDefault(p => p.OrderId == orderId && p.OrderDate != null);
        }

        public Order GetCartByUserId(string userId)
        {
            return _context.Orders.Include(p => p.Employee)
                                  .Include(p => p.Client)
                                  .Include(p => p.OrderItems)
                                  .ThenInclude(pi => pi.Product)
                                  .FirstOrDefault(p => p.ClientId == userId && p.OrderDate == null);
        }
    }
}
