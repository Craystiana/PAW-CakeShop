using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CakeShop.Web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cart()
        {
            return View("~/Views/Cart/Cart.cshtml");
        }
    }
}
