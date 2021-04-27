using CakeShop.Web.DataAccess.Entities;
using CakeShop.Web.DataAccess.Repository;
using CakeShop.Web.Models.Account;

namespace CakeShop.Web.Services
{
    public class UserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(int userId)
        {
            return _userRepository.Get(userId);
        }

        public void Edit(ProfileViewModel profile)
        {
            var existingUser = _userRepository.Get(profile.UserId);

            existingUser.LastName = profile.LastName;
            existingUser.FirstName = profile.FirstName;
            existingUser.EmailAddress = profile.EmailAddress;
            existingUser.Gender = profile.Gender;
            existingUser.Address = profile.Address;
            existingUser.PhoneNumber = profile.PhoneNumber;

            _userRepository.SaveChanges();
        }
    }
}
