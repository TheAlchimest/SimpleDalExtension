namespace Demo.Model.DomainClasses
{
    using System;

    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int OrderNo { get; set; }
        public int ItemsCount { get; set; }
        public double ProductCost { get; set; }
        public double ShippingCost { get; set; }
        public double TotalCost { get; set; }
        public double TotalPaied { get; set; }
        public int OrderStatusID { get; set; }
        public int PaymentMethodID { get; set; }
        public System.DateTime OrderRequestDate { get; set; }
        public System.DateTime OrderDate { get; set; }
        public Nullable<System.DateTime> LastModificationDate { get; set; }
        public int ShippingMethodID { get; set; }
        public string ShippingCode { get; set; }
        public Nullable<System.DateTime> ShippingDate { get; set; }
        public Nullable<System.DateTime> DeliveringDate { get; set; }
        public bool IsReceivingConfirmed { get; set; }
        public Nullable<System.DateTime> RecievingConfirmationDate { get; set; }
        public int UserRatingForService { get; set; }
        public string AdminNote { get; set; }
        public string UserNote { get; set; }
        public int LangId { get; set; }
        public int OrderRequestID { get; set; }



        #region //Additional Data//--------------------
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
        public string ShippmentMethod { get; set; }
        public string ShippedTo { get; set; }


        #endregion
    }

}
