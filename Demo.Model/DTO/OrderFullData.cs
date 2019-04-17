using Demo.Model.DomainClasses;
using System.Collections.Generic;

namespace Demo.Model.DTO
{
    public class OrderDataWithDetails
    {
        public Order OrderData { get; set; }
        public List<OrderItem> ItemsList { get; set; }
        public OrderAddress ShippingAddress { get; set; }
        public bool IsValid { get; set; }
        public OrderDataWithDetails()
        {
            ItemsList = new List<OrderItem>();
        }

    }
}
