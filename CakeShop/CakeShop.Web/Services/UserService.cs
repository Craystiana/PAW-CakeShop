using CakeShop.Web.DataAccess.Entities;
using CakeShop.Web.DataAccess.Repository;
using CakeShop.Web.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CakeShop.Web.Services
{
    public class UserService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IRepository<User> _userRepository;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IRepository<User> userRepository)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public User GetUser(string userId)
        {
            return _userRepository.Get(userId);
        }

        public bool IsUserLoggedIn(ClaimsPrincipal User)
        {
            return _signInManager.IsSignedIn(User);
        }

        public async Task<IdentityResult> Register(RegisterViewModel model)
        {
           
            var user = new User { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, Gender = model.Gender, Address = model.Address };
            
            using (var stream = new BinaryReader(model.Photo.OpenReadStream()))
            {
                user.Photo = stream.ReadBytes((int)model.Photo.Length);
            }

            var result = await _userManager.CreateAsync(user, model.Password);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Client");
            }

            return result;
        }

        public async Task<SignInResult> Login(LoginViewModel model)
        {
            SignInResult signInResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            return signInResult;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }


        public void Edit(ProfileViewModel profile, string userId)
        {
            var existingUser = _userRepository.Get(userId);

            existingUser.LastName = profile.LastName;
            existingUser.FirstName = profile.FirstName;
            existingUser.UserName = profile.EmailAddress;
            existingUser.Email = profile.EmailAddress;
            existingUser.Gender = profile.Gender;
            existingUser.Address = profile.Address;
            existingUser.PhoneNumber = profile.PhoneNumber;

            _userManager.UpdateAsync(existingUser);
            _userRepository.SaveChanges();
        }
    }
}
