using System.ComponentModel.DataAnnotations;

namespace CakeShop.Web.Models.User
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string EmailAddress { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int UserRoleId { get; set; }
    }
}
