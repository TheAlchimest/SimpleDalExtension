namespace Demo.Model.DomainClasses
{
    public class OrderRequestDetails
    {
        public int OrderRequestDetailID { get; set; }
        public int OrderRequestID { get; set; }
        public int ProductID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double ShippingCost { get; set; }
        public int ShippingMethodID { get; set; }
    }
}
