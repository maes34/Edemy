namespace WebUI.Dtos
{
    public class PayDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string IdentityNumber { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string CardDate { get; set; } = string.Empty;
        public int CVV { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippingDate { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
        public string BillingAddress { get; set; } = string.Empty;
        public string OrderStatus { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        public string TrackingNumber { get; set; } = string.Empty;
        public decimal? DiscountAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string DiscountCode { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
