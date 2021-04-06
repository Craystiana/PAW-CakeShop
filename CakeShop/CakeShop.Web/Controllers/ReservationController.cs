using CakeShop.Web.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CakeShop.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ILogger<ReservationController> _logger;

        public ReservationController(ILogger<ReservationController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ReservationList()
        {
            return View("~/Views/Reservation/ReservationList.cshtml");
        }

        public IActionResult ReservationDetails()
        {
            return View("~/Views/Reservation/ReservationDetails.cshtml");
        }

        public IActionResult ReservationAdd()
        {
            return View("~/Views/Reservation/ReservationAdd.cshtml");
        }
    }
}
