using CakeShop.Web.Common.Enums;
using CakeShop.Web.DataAccess;
using CakeShop.Web.DataAccess.Entities;
using CakeShop.Web.Models;
using CakeShop.Web.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CakeShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly Context _context;

        public AccountController(ILogger<AccountController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            try
            {
                return RedirectToAction("Index", "Home");
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Login failed");
                return View("~/Views/Account/Login.cshtml");
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("~/Views/Account/Register.cshtml");
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            try
            {
                var newUser = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    EmailAddress = model.Email,
                    Password = model.Password,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    UserRoleId = (int)UserRoleType.Client,
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Register failed");
                return View("~/Views/Account/Register.cshtml");
            }
        }


        public IActionResult Profile()
        {
            var model = _context.Users.Find(1);

            var viewmodel = new ProfileViewModel
            {
                UserId = model.UserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                EmailAddress = model.EmailAddress,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
            };

            return View("~/Views/Account/Profile.cshtml", viewmodel);
        }

        [HttpPost]
        public IActionResult EditProfile(ProfileViewModel model)
        {
            try
            {
                var user = _context.Users.Find(1);
                user.Address = model.Address;

                _context.SaveChanges();

                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Register failed");
                return View("~/Views/Account/Register.cshtml");
            }
        }
    }
}
