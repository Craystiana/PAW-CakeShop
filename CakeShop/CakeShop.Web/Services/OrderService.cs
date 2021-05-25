using CakeShop.Web.DataAccess.Entities;
using CakeShop.Web.DataAccess.Repository;
using CakeShop.Web.Models.Order;
using CakeShop.Web.Models.Product;
using CakeShop.Web.Models.User;
using System;
using System.Collections.Generic;

namespace CakeShop.Web.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;
        private readonly IRepository<OrderItem> _orderItemRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<OrderItem> orderItemRepository)
        {
            _orderRepository = (OrderRepository)orderRepository;
            _orderItemRepository = orderItemRepository;
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
                        UserId = order.Employee.Id,
                        FirstName = order.Employee.LastName,
                        LastName = order.Employee.FirstName,
                        Gender = order.Employee.Gender,
                        EmailAddress = order.Employee.Email,
                        Address = order.Employee.Address,
                        PhoneNumber = order.Employee.PhoneNumber
                    },
                    Customer = new UserViewModel
                    {
                        UserId = order.Client.Id,
                        FirstName = order.Client.LastName,
                        LastName = order.Client.FirstName,
                        Gender = order.Client.Gender,
                        EmailAddress = order.Client.Email,
                        Address = order.Client.Address,
                        PhoneNumber = order.Client.PhoneNumber
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
                    UserId = order.Employee.Id,
                    FirstName = order.Employee.LastName,
                    LastName = order.Employee.FirstName,
                    Gender = order.Employee.Gender,
                    EmailAddress = order.Employee.Email,
                    Address = order.Employee.Address,
                    PhoneNumber = order.Employee.PhoneNumber
                },
                Customer = new UserViewModel
                {
                    UserId = order.Client.Id,
                    FirstName = order.Client.LastName,
                    LastName = order.Client.FirstName,
                    Gender = order.Client.Gender,
                    EmailAddress = order.Client.Email,
                    Address = order.Client.Address,
                    PhoneNumber = order.Client.PhoneNumber
                },
                Products = new List<OrderItemViewModel>()
            };

            foreach(var orderProduct in orderProducts)
            {
                orderModel.Products.Add(new OrderItemViewModel
                {
                    ProductId = orderProduct.Product.ProductId,
                    ProductName = orderProduct.Product.Name,
                    ProductPrice = orderProduct.Product.Price,
                    Quantity = orderProduct.Quantity
                });
            }

            return orderModel;
        }

        public OrderViewModel GetCart(string userId)
        {
            var order = _orderRepository.GetCartByUserId(userId);

            if (order != null)
            {
                var orderProducts = order.OrderItems;

                var orderModel = new OrderViewModel
                {
                    OrderId = order.OrderId,
                    ClientId = order.ClientId,
                    EmployeeId = order.EmployeeId,
                    Customer = new UserViewModel
                    {
                        UserId = order.Client.Id,
                        FirstName = order.Client.LastName,
                        LastName = order.Client.FirstName,
                        Gender = order.Client.Gender,
                        EmailAddress = order.Client.Email,
                        Address = order.Client.Address,
                        PhoneNumber = order.Client.PhoneNumber
                    },
                    Products = new List<OrderItemViewModel>()
                };

                foreach (var orderProduct in orderProducts)
                {
                    orderModel.Products.Add(new OrderItemViewModel
                    {
                        ProductId = orderProduct.Product.ProductId,
                        ProductName = orderProduct.Product.Name,
                        ProductPrice = orderProduct.Product.Price,
                        Quantity = orderProduct.Quantity,
                        Photo = orderProduct.Product.Photo
                    });
                }

                return orderModel;
            }
            else
            {
                return null;
            }
        }

        public void AddToCart(int productId, string userId)
        {
            var userCart = _orderRepository.GetCartByUserId(userId);

            if (userCart != null)
            {
                var productFound = false;
                foreach (var product in userCart.OrderItems)
                {
                    if (product.ProductId == productId)
                    {
                        productFound = true;
                        product.Quantity++;
                        _orderItemRepository.SaveChanges();
                    }
                }

                if (!productFound)
                {
                    var orderItem = new OrderItem
                    {
                        ProductId = productId,
                        OrderId = userCart.OrderId,
                        Quantity = 1
                    };
                    _orderItemRepository.Add(orderItem);
                    _orderItemRepository.SaveChanges();
                }
            }
            else
            {
                var order = new Order
                {
                    ClientId = userId,
                    OrderDate = null,
                    EmployeeId = "c42f96e1-51db-43a0-9099-8ea555d03a9d"
                };
                _orderRepository.Add(order);
                _orderRepository.SaveChanges();

                var orderItem = new OrderItem
                {
                    ProductId = productId,
                    OrderId = order.OrderId,
                    Quantity = 1
                };
                _orderItemRepository.Add(orderItem);
                _orderRepository.SaveChanges();
            }

        }

        public void IncreaseProductQuantity(int productId, string userId)
        {
            var userCart = _orderRepository.GetCartByUserId(userId);

            foreach (var product in userCart.OrderItems)
            {
                if (product.ProductId == productId)
                {
                    product.Quantity++;
                    _orderItemRepository.SaveChanges();
                }
            }
        }

        public void DecreaseProductQuantity(int productId, string userId)
        {
            var userCart = _orderRepository.GetCartByUserId(userId);

            foreach (var product in userCart.OrderItems)
            {
                if (product.ProductId == productId)
                {
                    if (product.Quantity > 1)
                    {
                        product.Quantity--;
                        _orderItemRepository.SaveChanges();
                    }
                    else
                    {
                        _orderItemRepository.Remove(_orderItemRepository.Get(product.OrderItemId));
                        _orderItemRepository.SaveChanges();
                    }
                }
            }
        }

        public void DeleteCartItem(int productId, string userId)
        {
            var userCart = _orderRepository.GetCartByUserId(userId);

            foreach (var product in userCart.OrderItems)
            {
                if (product.ProductId == productId)
                {
                    _orderItemRepository.Remove(_orderItemRepository.Get(product.OrderItemId));
                    _orderItemRepository.SaveChanges();
                    break;
                }
            }
        }

        public void PlaceOrder(string userId)
        {
            var userCart = _orderRepository.GetCartByUserId(userId);
            userCart.OrderDate = DateTime.Now;
            _orderRepository.SaveChanges();
        }
    }
}
