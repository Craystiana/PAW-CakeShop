using CakeShop.Web.DataAccess.Entities;
using CakeShop.Web.DataAccess.Repository;
using CakeShop.Web.Models.Order;
using CakeShop.Web.Models.Product;
using CakeShop.Web.Models.User;
using System.Collections.Generic;

namespace CakeShop.Web.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = (OrderRepository)orderRepository;
        }

        public IEnumerable<OrderViewModel> GetAll()
        {
            var orders =  _orderRepository.GetAllOrders();
            
            foreach(var order in orders)
            {
                yield return new OrderViewModel
                {
                    OrderId = order.OrderId,
                    ClientId = order.ClientId,
                    EmployeeId = order.EmployeeId,
                    OrderDate = order.OrderDate,
                    Employee = new UserViewModel
                    {
                        UserId = order.Employee.UserId,
                        FirstName = order.Employee.LastName,
                        LastName = order.Employee.FirstName,
                        Gender = order.Employee.Gender,
                        EmailAddress = order.Employee.EmailAddress,
                        Address = order.Employee.Address,
                        PhoneNumber = order.Employee.PhoneNumber,
                        UserRoleId = order.Employee.UserRoleId
                    },
                    Customer = new UserViewModel
                    {
                        UserId = order.Client.UserId,
                        FirstName = order.Client.LastName,
                        LastName = order.Client.FirstName,
                        Gender = order.Client.Gender,
                        EmailAddress = order.Client.EmailAddress,
                        Address = order.Client.Address,
                        PhoneNumber = order.Client.PhoneNumber,
                        UserRoleId = order.Client.UserRoleId
                    }
                };
            }
        }

        public OrderViewModel GetById(int orderId)
        {
            var order = _orderRepository.GetOrder(orderId);
            var orderProducts = order.OrderItems;

            var orderModel = new OrderViewModel
            {
                OrderId = order.OrderId,
                ClientId = order.ClientId,
                EmployeeId = order.EmployeeId,
                OrderDate = order.OrderDate,
                Employee = new UserViewModel
                {
                    UserId = order.Employee.UserId,
                    FirstName = order.Employee.LastName,
                    LastName = order.Employee.FirstName,
                    Gender = order.Employee.Gender,
                    EmailAddress = order.Employee.EmailAddress,
                    Address = order.Employee.Address,
                    PhoneNumber = order.Employee.PhoneNumber,
                    UserRoleId = order.Employee.UserRoleId
                },
                Customer = new UserViewModel
                {
                    UserId = order.Client.UserId,
                    FirstName = order.Client.LastName,
                    LastName = order.Client.FirstName,
                    Gender = order.Client.Gender,
                    EmailAddress = order.Client.EmailAddress,
                    Address = order.Client.Address,
                    PhoneNumber = order.Client.PhoneNumber,
                    UserRoleId = order.Client.UserRoleId
                },
                Products = new List<OrderItemViewModel>()
            };

            foreach(var orderProduct in orderProducts)
            {
                orderModel.Products.Add(new OrderItemViewModel
                {
                    ProductName = orderProduct.Product.Name,
                    ProductPrice = orderProduct.Product.Price,
                    Quantity = orderProduct.Quantity
                });
            }

            return orderModel;
        }
    }
}
