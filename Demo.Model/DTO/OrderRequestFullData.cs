using Demo.Model.DomainClasses;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Model.DTO
{
    public class OrderRequestFullData
    {
        public OrderRequest RequsetData { get; set; }
        public List<OrderRequsetItem> ItemsList { get; set; }
        public OrderRequestAddress ShippingAddress { get; set; }
        public OrderConfirmationFormDto RequestFormDto { get; set; }
        
        public bool IsValid { get; set; }
        public OrderRequestFullData() {
            ItemsList = new List<OrderRequsetItem>();
        }

    }
}
