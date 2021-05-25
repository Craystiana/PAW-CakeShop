using CakeShop.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace CakeShop.Web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly UserService _userService;
        private readonly OrderService _orderService;

        public CartController(ILogger<CartController> logger, UserService userService, OrderService orderService)
        {
            _logger = logger;
            _userService = userService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = _orderService.GetCart(userId);

            return View("~/Views/Cart/Cart.cshtml", cart); 
        }

        public IActionResult IncreaseProductQuantity(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _orderService.IncreaseProductQuantity(productId, userId);

            var cart = _orderService.GetCart(userId);
            return View("~/Views/Cart/Cart.cshtml", cart);
        }

        public IActionResult DecreaseProductQuantity(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _orderService.DecreaseProductQuantity(productId, userId);

            var cart = _orderService.GetCart(userId);
            return View("~/Views/Cart/Cart.cshtml", cart);
        }

        public IActionResult DeleteProduct(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _orderService.DeleteCartItem(productId, userId);

            var cart = _orderService.GetCart(userId);
            return View("~/Views/Cart/Cart.cshtml", cart);
        }

        public IActionResult PlaceOrder()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _orderService.PlaceOrder(userId);

            var cart = _orderService.GetCart(userId);
            return View("~/Views/Cart/Cart.cshtml", cart);
        }
    }
}
