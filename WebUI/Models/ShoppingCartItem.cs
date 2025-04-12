namespace WebUI.Models
{
    public class ShoppingCartItem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal ProductUnitPrice { get; set; }
        public decimal Amount => ProductUnitPrice * Quantity; // Bir Prop başka Propların değerlerini kullanarak işlem yapıp sonucu kendisinde saklayabilir.
    }
}
