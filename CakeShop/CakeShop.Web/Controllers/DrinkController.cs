using CakeShop.Web.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CakeShop.Web.Controllers
{
    public class DrinkController : Controller
    {
        private readonly ILogger<DrinkController> _logger;

        public DrinkController(ILogger<DrinkController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DrinkList()
        {
            return View("~/Views/Menu/Drink/DrinkList.cshtml");
        }
    }
}
