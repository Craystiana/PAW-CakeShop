using CakeShop.Web.Models.Account;
using CakeShop.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CakeShop.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EmployeeList()
        {
            return View("~/Views/Employee/EmployeeList.cshtml");
        }

        public IActionResult EmployeeDetails()
        {
            return View("~/Views/Employee/EmployeeDetails.cshtml");
        }
    }
}
