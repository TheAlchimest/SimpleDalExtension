namespace Demo.Model.DomainClasses
{
    using System;

    public class OrderDetails
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double ShippingCost { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public int ShippingMethodID { get; set; }
        public string ShippingCode { get; set; }
        public Nullable<System.DateTime> ShippingDate { get; set; }
        public Nullable<System.DateTime> DeliveringDate { get; set; }
        public bool IsReceivingConfirmed { get; set; }
        public Nullable<System.DateTime> RecievingConfirmationDate { get; set; }
        public string SupplierNote { get; set; }
        public int UserRate { get; set; }
        public string UserFeedBack { get; set; }

    }
}
