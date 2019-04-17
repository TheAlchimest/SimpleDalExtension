
namespace Demo.Model.DomainClasses
{
    public class OrderRequest
    {

        public int OrderRequestID { get; set; }
        public int UserID { get; set; }
        public int OrderRequestNo { get; set; }
        public int ItemsCount { get; set; }
        public double ProductCost { get; set; }
        public double ShippingCost { get; set; }
        public double TotalCost { get; set; }
        public double TotalPaied { get; set; }
        public int OrderStatusID { get; set; }
        public int PaymentMethodID { get; set; }
        public int ShippingMethodID { get; set; }
        public string UserNote { get; set; }
        public System.DateTime OrderRequestDate { get; set; }
        public int LangId { get; set; }

        
    }
}
