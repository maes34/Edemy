using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Order : CoreEntity
    {
        public int CustomerID { get; set; }
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
