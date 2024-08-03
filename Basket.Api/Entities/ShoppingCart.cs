namespace Basket.Api.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; } = null!;
        public List<CartItem> CartItems { get; set; } = new();
        public decimal TotalPrice { get => CartItems.Sum(x => x.Quantity * x.Price); }

        public ShoppingCart(){}
        public ShoppingCart(string userName) => UserName = userName;
        
    }
}
