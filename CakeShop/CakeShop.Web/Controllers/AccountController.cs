using CakeShop.Web.Common.Enums;
using CakeShop.Web.DataAccess;
using CakeShop.Web.DataAccess.Entities;
using CakeShop.Web.Models;
using CakeShop.Web.Models.Account;
using CakeShop.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CakeShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserService _userService;

        public AccountController(ILogger<AccountController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
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

                //_context.Users.Add(newUser);
                //_context.SaveChanges();

                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Register failed");
                return View("~/Views/Account/Register.cshtml");
            }
        }

        [HttpGet]
        public IActionResult Profile(int userId)
        {
            var user = _userService.GetUser(userId);

            var model = new ProfileViewModel
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                EmailAddress = user.EmailAddress,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
            };

            return View("~/Views/Account/Profile.cshtml", model);
        }

        [HttpPost]
        public IActionResult EditProfile(ProfileViewModel profile)
        {
            try
            {
                _userService.Edit(profile);
                return RedirectToAction("EditProfile", profile.UserId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Register failed");
                return View("~/Views/Account/Register.cshtml");
            }
        }
    }
}
