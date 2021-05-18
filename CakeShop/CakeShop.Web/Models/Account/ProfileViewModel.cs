namespace CakeShop.Web.Models.Account
{
    public class ProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] Photo { get; set; }
        public string Role { get; set; }
    }
}
