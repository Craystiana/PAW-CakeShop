using CakeShop.Web.Models.Account;
using CakeShop.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NToastNotify;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CakeShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserService _userService;
        private readonly IToastNotification _notyf;

        public AccountController(ILogger<AccountController> logger, UserService userService, IToastNotification notyf)
        {
            _logger = logger;
            _userService = userService;
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (_userService.IsUserLoggedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }

            return View("~/Views/Account/Register.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userService.Register(model);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");
                        _notyf.AddSuccessToastMessage("Congratulations, your account has been created. Please log in!");
                        return RedirectToAction("Login");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

                _notyf.AddErrorToastMessage("There were some errors during registration. Please try again!");
                return View(model);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Register failed");
                _notyf.AddErrorToastMessage("There were some errors during registration. Please try again!");
                return View("~/Views/Account/Register.cshtml");
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (_userService.IsUserLoggedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }

            return View("~/Views/Account/Login.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userService.Login(model);
                    if(result.Succeeded)
                    {
                        _notyf.AddSuccessToastMessage("Succesfully logged in! Welcome " + model.Email + "!");
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Invalid login attempt");
                }
                _notyf.AddErrorToastMessage("Email or password are incorrect. Please try again!");
                return RedirectToAction("Login");
            }
            catch
            {
                _notyf.AddErrorToastMessage("Email or password are incorrect. Please try again!");
                return View("~/Views/Account/Login.cshtml");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            _notyf.AddSuccessToastMessage("Succesfully logged out!");
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Profile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userRole = User.FindFirstValue(ClaimTypes.Role);

            var user = _userService.GetUser(userId);

            var model = new ProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                EmailAddress = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                Photo = user.Photo,
                Role = userRole,
            };

            return View("~/Views/Account/Profile.cshtml", model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditProfile(ProfileViewModel profile)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _userService.Edit(profile, userId);
                return RedirectToAction("Profile");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Register failed");
                return View("~/Views/Account/Register.cshtml");
            }
        }
    }
}
