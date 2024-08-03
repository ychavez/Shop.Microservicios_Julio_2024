namespace Basket.Api.Entities
{
    public class CartItem
    {
        public int Quantity { get; set; }
        public string? Color { get; set; }
        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
