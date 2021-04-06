using CakeShop.Web.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CakeShop.Web.Controllers
{
    public class CakeController : Controller
    {
        private readonly ILogger<CakeController> _logger;

        public CakeController(ILogger<CakeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CakeList()
        {
            return View("~/Views/Menu/Cake/CakeList.cshtml");
        }

        public IActionResult CakeDetails()
        {
            return View("~/Views/Menu/Cake/CakeDetails.cshtml");
        }

        public IActionResult CakeAdd()
        {
            return View("~/Views/Menu/Cake/CakeAdd.cshtml");
        }
    }
}
