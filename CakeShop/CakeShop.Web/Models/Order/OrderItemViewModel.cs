namespace CakeShop.Web.Models.Order
{
    public class OrderItemViewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int ProductPrice { get; set; }

        public int Quantity { get; set; }

        public byte[] Photo { get; set; }
    }
}
