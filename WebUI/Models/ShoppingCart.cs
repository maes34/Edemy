namespace WebUI.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> shoppingCartItems { get; set; } = new List<ShoppingCartItem>();
        public decimal TotalAmount { get; set; } // Sepet toplam tutarı

    }
}
