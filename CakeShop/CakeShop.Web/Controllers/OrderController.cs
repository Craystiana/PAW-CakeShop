using CakeShop.Web.Models.Account;
using CakeShop.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CakeShop.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly OrderService _orderService;

        public OrderController(ILogger<OrderController> logger, OrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult List()
        {
            var orders = _orderService.GetAll();
            return View("~/Views/Order/List.cshtml", orders);
        }

        [HttpGet]
        public IActionResult Details(int orderId)
        {
            var order = _orderService.GetById(orderId);
            return View("~/Views/Order/Details.cshtml", order);
        }

        public IActionResult Add()
        {
            return View("~/Views/Order/Add.cshtml");
        }
    }
}
